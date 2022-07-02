using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevelopmentInfo.CodeSamples
{
    public class Internationalization
    {
        public void TwoRegionDemo()
        {
            Console.WriteLine("Starting method: TwoRegionDemo()");
            const int value = 5600;
            
            // Spanish Chile
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-CL");
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine(value.ToString("c"));

            // Spanish Mexico
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine(value.ToString("c"));
        }
    }
}
