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

        public string CapitalizeFirstLetterOfEveryWord(string phrase)
        {            
            var sb = new StringBuilder();

            foreach(string word in phrase.Split(' '))
            {
                string firstChar = word[0].ToString().ToUpper();
                string capWord = firstChar + word.Substring(1) + " ";
                sb.Append(capWord);
            }
                        
            return sb.ToString().TrimEnd();
        }
        // Another way:
        // return String.Join(" ", phrase.Split().Select(i => Char.ToUpper(i[0]) + i.Substring(1)))

        public bool IsSquare(int n)
        {
            int val = 0;

            for(int i = 0; val < n; i++)
            {
                val = i * i;
            }

            return val == n;
        }
        // Another way:
        // return Math.Sqrt(n) % 1 == 0;  or  => (Math.Sqrt(n) % 1 == 0);

        /// <summary>
        /// To be a senior, a member must be at least 55 years old and have a handicap greater than 7. 
        /// In this croquet club, handicaps range from -2 to +26; the better the player the lower the handicap.
        /// </summary>
        /// Parameters: Age, Handicap
        /// <returns>Array of "Senior" or "Open"</returns>
        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            
            for(int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    // Age  Handicap
                    if ((data[i][j] > 55)) && ((data[i][j] > 55)
                }
            }
        }
    }
}



