/*
   Name:         geo_extends
   Version:      1.0
   Author:       Angelos Tzotsos <tzotsos@gmail.com>
   Date:         06/12/09
   Modified:     03/11/10
   Description:  Calculation of bounding box for any gdal-supported geospatial data file (EPSG:2100 to EPSG:4326)

   Copyright (C) November 2010 Angelos Tzotsos <tzotsos@gmail.com>

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

#include <stdio.h>
#include <stdlib.h>
#include "gdal/gdal.h"
#include "gdal/ogr_core.h"
#include "gdal/ogr_api.h"
#include "gdal/ogr_srs_api.h"



int main(int argc, char *argv[])
{
    GDALDatasetH  hDataset = NULL;
    OGRDataSourceH hDS = NULL;
    OGRSFDriverH *pahDriver = NULL;
    OGRLayerH hLR = NULL;
    OGREnvelope hEnv;


    double adfGeoTransform[6];
    int columns, lines;
    double minx, miny, maxx, maxy, x, y, z;
    register int i;
    FILE *fin=NULL;

    if(argc != 2)
    {
        printf("Usage: geo_extends <input file>\n");
        return 1;
    }

    GDALAllRegister();
    OGRRegisterAll();



    char *egsa = "PROJCS[\"GGRS87 / Greek Grid\",GEOGCS[\"GGRS87\",DATUM[\"Greek_Geodetic_Reference_System_1987\",SPHEROID[\"GRS 1980\",6378137,298.257222101,AUTHORITY[\"EPSG\",\"7019\"]],TOWGS84[-199.87,74.79,246.62,0,0,0,0],AUTHORITY[\"EPSG\",\"6121\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4121\"]],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",0],PARAMETER[\"central_meridian\",24],PARAMETER[\"scale_factor\",0.9996],PARAMETER[\"false_easting\",500000],PARAMETER[\"false_northing\",0],AUTHORITY[\"EPSG\",\"2100\"],AXIS[\"Easting\",EAST],AXIS[\"Northing\",NORTH]]";
    char *wgs = "GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563,AUTHORITY[\"EPSG\",\"7030\"]],AUTHORITY[\"EPSG\",\"6326\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4326\"]]";

    OGRSpatialReferenceH oSourceSRS;
    OGRSpatialReferenceH oTargetSRS;

    oSourceSRS = OSRNewSpatialReference(NULL);
    oTargetSRS = OSRNewSpatialReference(NULL);
    OSRImportFromWkt(oSourceSRS, &egsa);
    OSRImportFromWkt(oTargetSRS, &wgs);

    OGRCoordinateTransformationH poCT;
    poCT = OCTNewCoordinateTransformation(oSourceSRS, oTargetSRS);

    hDataset = GDALOpen(argv[1], GA_ReadOnly);
    if(hDataset != NULL)//It is raster
    {
        columns = GDALGetRasterXSize(hDataset);
        lines = GDALGetRasterYSize(hDataset);

        if(GDALGetGeoTransform(hDataset, adfGeoTransform) == CE_None)
        {
            minx = (adfGeoTransform[0] - (adfGeoTransform[1] / 2));
            maxy = (adfGeoTransform[3] - (adfGeoTransform[5] / 2));
            miny = (maxy + ((lines + 1) * adfGeoTransform[5]));
            maxx = (minx + (adfGeoTransform[1] * (columns + 1)));
            OCTTransform(poCT, 1, &minx, &miny, 0);
            OCTTransform(poCT, 1, &maxx, &maxy, 0);
            printf("BoundingBox: %f %f %f %f\n",minx ,miny, maxx, maxy);
            GDALClose (hDataset);
        }
        else
        {
            printf("Failure: No Georeference info found for this raster file\n");
            return 0;
        }
    }
    else//Try if it is vector
    {
        hDS = OGROpen( argv[1], FALSE , pahDriver );
        if( hDS == NULL )//Not vector
        {
            //Parse for DTM file
            fin=fopen(argv[1],"r");
            fseek(fin,0L,SEEK_SET);
            minx=50000000.0;
            miny=50000000.0;
            maxx=0.0;
            maxy=0.0;
            while(!feof(fin))
            {
                fscanf(fin,"%lf,%lf,%lf\n",&x,&y,&z);

                if(ferror(fin))//input error
                {
                    printf("Failure: Unsupported file type\n");
                    return 0;
                }

                if(x>maxx) maxx=x;
                if(y>maxy) maxy=y;
                if(x<minx) minx=x;
                if(y<miny) miny=y;
            }

            if(minx==50000000.0 || miny==50000000.0)
            {
                printf("Failure: Unsupported file type\n");
                return 0;
            }

            if(maxx==0 || maxy==0)
            {
                printf("Failure: Unsupported file type\n");
                return 0;
            }

            if(minx==maxx)
            {
                minx-=1;
                maxx+=1;
            }
            if(miny==maxy)
            {
                miny-=1;
                maxy+=1;
            }

            //DTM file
            OCTTransform(poCT, 1, &minx, &miny, 0);
            OCTTransform(poCT, 1, &maxx, &maxy, 0);
            printf("BoundingBox: %f %f %f %f\n",minx ,miny, maxx, maxy);
            return 0;
        }

        //It is vector
        for(i=0; i< OGR_DS_GetLayerCount (hDS); i++)
        {
            hLR = OGR_DS_GetLayer(hDS, i);
            if(OGR_L_GetExtent (hLR, &hEnv, FALSE) == OGRERR_NONE)
            {
                minx = hEnv.MinX;
                miny = hEnv.MinY;
                maxx = hEnv.MaxX;
                maxy = hEnv.MaxY;
                OCTTransform(poCT, 1, &minx, &miny, 0);
                OCTTransform(poCT, 1, &maxx, &maxy, 0);
                printf("BoundingBox: %f %f %f %f\n",minx ,miny, maxx, maxy);
            }
        }

        OGRReleaseDataSource( hDS );

    }
    return 0;
}
