Welcome to GIMED v1.2

This is a Free (as in freedom) Metadata Editor for geospatial data, following ISO19139 and INSPIRE directive.

Features:
- Same GUI elements as INSPIRE Geoportal
- Automatic identification of Geographic Extends for raster and vector files using the Greek Reference System (EPSG:2100)
- Metadata Validation. XML files created by GIMED pass validation of INSPIRE Geoportal's Metadata Editor.
- Support for Datasets

Comming Soon:
- Batch Creation of Metadata
- Batch Validation and Editing
- Support for Data Series

Installation:

GIMED is developed in C#. The code is compatible with both Mono and .NET Framework, thus both
GNU\Linux and Microsoft Windows operating systems are supported.

For installation, just unpack the archive in any folder of your system and execute the binary. In GNU\Linux you need to 
execute using the command "mono GIMED.exe"

For the Geographic Extend module, GDAL must be installed on your system.
If you use GNU\Linux, use your distributions package manager to obtain the latest libgdal and libgdal-dev.
Next, compile the module geo_extends.c against the libgdal-dev and place the binary file in the same folder as
the GIMED binary file. If you don't get any warnings during GIMED startup, then all modules are in place.
If you use Windows, you should download FWTools from (http://fwtools.maptools.org/) and place the FWTools/bin 
directory in your systems path. Again the geo_extends.exe provided within the archive should be placed in the same folder as 
GIMED.exe

For problems / suggestions / bugs etc please contact Angelos Tzotsos (tzotsos@gmail.com)

 