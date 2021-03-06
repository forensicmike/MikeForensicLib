﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeForensicLib
{
    static public class ProcessHelpers
    {
        static public Process RunNoWindow(this ProcessStartInfo psi)
        {
            var result = string.Empty;
            //ProcessStartInfo start = new ProcessStartInfo();
            //start.FileName = PythonPath;
            //start.Arguments = string.Format("\"{0}\" {1}", cmd, args);
            psi.UseShellExecute = false;// Do not use OS shell
            psi.CreateNoWindow = true; // We don't need new window
            psi.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            psi.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            return Process.Start(psi);
            //using (Process process = Process.Start(psi))
            //{
            //    using (StreamReader reader = process.StandardOutput)
            //    {
            //        string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
            //        result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
            //        return result;
            //    }
            //}

            //return result;
        }
    }
}
