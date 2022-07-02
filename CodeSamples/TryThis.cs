using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentInfo.CodeSamples
{
    public class TryThis
    {
        public void GenerateListOfTimes()
        {
            var eventTimes = new Dictionary<int, string>();
            var startTime = new DateTime( 2017, 1, 1, 0, 0, 0);
            var timeSpan = new TimeSpan(0, 30, 0);

            for(int i = 0; i < 48; i++)
            {
                eventTimes.Add(i, startTime.ToShortTimeString());
                startTime += timeSpan;
            }            
        }

        public void GenerateListOfThelast120Years()
        {
            int yearRange = 120;
            int currentYear = DateTime.Now.Year;

            var birthYears = new List<int>();

            for(int i = 0; i < yearRange; i++)
            {
                birthYears.Add(currentYear - i);
            }

            return;
        }

        public void GenerateFibonacciSeries()
        {
            GetFibonacciSeries(0);
            GetFibonacciSeries(1);
            GetFibonacciSeries(2);
            GetFibonacciSeries(3);
            GetFibonacciSeries(4);
            GetFibonacciSeries(5);
            GetFibonacciSeries(6);
            GetFibonacciSeries(7);
            GetFibonacciSeries(8);
            Console.ReadLine();
        }

        private void GetFibonacciSeries(int length)
        {
            int firstNum = 0;
            int secondNum = 1;
            int result = 0;

            Console.WriteLine("Fibonacci Series Results for input: {0}", length);

            if (length == 0)
            {
                Console.WriteLine("0", length);
                return;
            }
            else if(length >= 1)
            {
                Console.WriteLine("0", length);
                Console.WriteLine("1", length);
            }
            
            for (int i = 2; i <= length; i++)
            {
                result = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = result;
                Console.WriteLine("{0}", result);
            }

            return;
        }
    }
}



