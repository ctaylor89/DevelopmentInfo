using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevelopmentInfo.CodeSamples
{
    public class FileOperations
    {
        public void WriteValuesToFile()
        {
            var floatValue = 4096.87f;
            var doubleValue = 5000.896;
            var intValue = 567;
            var uintValue = 1208;
            var boolValue = false;
            var stringValue = "House Rat";

            // This path will write to debug directory 
            // const string filePath = "dirWriteValues.txt";
            // This path will write to C:\_samples\DevelopmentInfo
            const string filePath = @"~\..\..\..\..\TestFiles\WriteValues.txt";

            // Create a file if it does not exist. Overwrite if exists.
            using (FileStream fs = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.Write("Here are some values:\r\n");
                sw.Write("{0}\r\n", floatValue);
                sw.Write("{0}\r\n", doubleValue);
                sw.Write("{0}\r\n", intValue);
                sw.Write("{0}\r\n", uintValue);
                sw.Write("{0}\r\n", boolValue);
                sw.Write("{0}\r\n", stringValue);
            }
        }
    }
}
