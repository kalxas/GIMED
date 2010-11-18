/*
   Name:         GIMED
   Version:      1.2.4
   Author:       Angelos Tzotsos <tzotsos@gmail.com>
   Date:         19/11/10
   Modified:     19/11/10
   Description:  Greek INSPIRE Metadata Editor 

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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Checker chk = new Checker();
        bool tmp = chk.CheckModules();
        Application.Run(new GIMEDForm_el(tmp));
    }

    
}

public class Checker
{
    public bool CheckModules()
    {

        string tmp = "";
        bool tmp2 = true;
        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        if (!CheckGDAL())
        {
            tmp += "Η βιβλιοθήκη GDAL δεν είναι εγκατεστημένη.\n";
        }

        if (!File.Exists(String.Format(appPath + "{0}geo_extends.exe", Path.DirectorySeparatorChar)) && !File.Exists(String.Format(appPath + "{0}geo_extends", Path.DirectorySeparatorChar)))
        {
            tmp += "Το πρόσθετο Γεωγραφικής Θέσης δεν είναι εγκατεστημένο.";
        }

        if (tmp != "")
        {
            MessageBox.Show(tmp);
            tmp2 = false;
        }
        return tmp2;
    }

    public static bool IsRunningOnMono()
    {
        return Type.GetType("Mono.Runtime") != null;
    }

    public bool IsUnix()
    {
        System.OperatingSystem osInfo = System.Environment.OSVersion;
        return (osInfo.ToString().IndexOf(@"Unix") != -1) ? true : false;
    }

    public bool IsWindows()
    {
        System.OperatingSystem osInfo = System.Environment.OSVersion;
        return (osInfo.ToString().IndexOf(@"Windows") != -1) ? true : false;
    }

    public bool CheckGDAL()
    {


        try
        {
            string appPath = "gdalinfo";

            StreamReader str0 = StreamReader.Null;
            string output = "";
            Process prc = new Process();
            prc.StartInfo.FileName = appPath;
            prc.StartInfo.Arguments = "--version";
            prc.StartInfo.UseShellExecute = false;
            prc.StartInfo.CreateNoWindow = true;
            prc.StartInfo.RedirectStandardOutput = true;
            prc.Start();
            str0 = prc.StandardOutput;
            output = str0.ReadToEnd();
            prc.WaitForExit();
            str0.Close();

            string[] SubStrings = output.Split(' ');
            return (SubStrings[0] == "GDAL") ? true : false;

        }
        catch
        {
            return false;
        }
    }
}
