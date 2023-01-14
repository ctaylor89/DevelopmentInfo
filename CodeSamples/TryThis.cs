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
            var startTime = new DateTime(2017, 1, 1, 0, 0, 0);
            var timeSpan = new TimeSpan(0, 30, 0);

            for (int i = 0; i < 48; i++)
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

            for (int i = 0; i < yearRange; i++)
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
            else if (length >= 1)
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

            // I had to use the static ForEach() of the Array class. Maybe because the training program uses a static method.
            Array.ForEach(phrase.Split(' '), s => sb.Append(Char.ToUpper(s[0]) + s.Substring(1) + " "));

            // This works in VS but not the training site
            //phrase.Split(' ').ForEach(s => sb.Append(Char.ToUpper(s[0]) + s.Substring(1) + " "));

            // My original way that works
            //foreach (string word in phrase.Split(' '))
            //{
            //    string firstChar = word[0].ToString().ToUpper();                
            //    sb.Append(firstChar + word.Substring(1) + " ");
            //}

            return sb.ToString().TrimEnd();
        }
        // Another way:
        // return String.Join(" ", phrase.Split().Select(i => Char.ToUpper(i[0]) + i.Substring(1)))

        public bool IsSquare(int n)
        {
            int val = 0;

            for (int i = 0; val < n; i++)
                val = i * i;

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
        //---------------------------------------------------------------------
        public IEnumerable<string> OpenOrSenior(int[][] data)
        {
            var result = new List<string>();
            

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][0] < 0 || (data[i][1] < -2 || data[i][1] > 26))
                {
                    result.Add("Open");
                    continue;
                }

                if ((data[i][0] >= 55) && (data[i][1] > 7))
                    result.Add("Senior");
                else
                    result.Add("Open");
            }

            return result;
        }

        public IEnumerable<string> OpenOrSenior2(int[][] inputArray)
        {
            // Tests each element in inputArray and selects "Senior" or "Open" then adds it to an IEnumerable<string>.
            return inputArray.Select(member => member[0] >= 55 && member[1] > 7 ? "Senior" : "Open").ToList();
            // Select method is an extension method of IEnuberable and it projects each element of a sequence into a new form.
        }

        public static IEnumerable<string> OpenOrSenior3(int[][] data)
        {
            foreach (int[] player in data)
            {
                if (player[0] >= 55 && player[1] > 7)
                {
                    yield return "Senior";          // Add "Senior" to the returned collection
                }
                else
                {
                    yield return "Open";
                }
            }
        }
        //---------------------------------------------------------------------
        // Accepts a string, and returns the same string with all even indexed characters in each word upper cased,
        // and all odd indexed characters in each word lower case.
        public string ToWeirdCase(string s)
        {
            var sb = new StringBuilder();
                        
            foreach(var word in s.Split(' '))
            {
                for(int i = 0; i < word.Length; i++)
                {
                    if(i % 2 == 0)
                        sb.Append(char.ToUpper(word[i]));
                    else
                        sb.Append(word[i]);
                }

                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }

        public string ToWeirdCase2(string s)
        {
            var sb = new StringBuilder();

            foreach (var word in s.Split(' '))
            {
                for (int i = 0; i < word.Length; i++)
                {
                  _ =  i % 2 == 0 ? sb.Append(char.ToUpper(word[i])) : sb.Append(word[i]);
                }

                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
        //---------------------------------------------------------------------
        // Given a positive integral number n, return a strictly increasing sequence
        // of numbers, so that the sum of the squares is equal to n².
        public int ConsonantCount(string str)
        {
            int countOut = 0;
            str = str.ToUpper().Trim();

            for(int i = 0; i < str.Length; i++)
            {
                int countCons = (from c in new char[] { 'A', 'E', 'I', 'O', 'U' }
                                where c == str[i]
                                select c).Count();
                                
                if(countCons == 0)
                {
                    if (str[i] > (char)64 && str[i] < 91)
                        countOut++;
                }   
            }

            return countOut;
        }
        
        public static int ConsonantCount2(string str)
        {
            return str.ToLower()
                      .Where(x => Char.IsLetter(x) && !"aeiou".Contains(x))
                      .Count();
        }
        //---------------------------------------------------------------------

        public static void MainCaller()
        {
            Console.WriteLine("Hello World");            
            string result = IsPalindrome("Mom") ? "Is a PD" : "Is NOT PD";
            Console.WriteLine(result);
        }

        public static bool IsPalindrome(string word)
        {
            var sb = new StringBuilder(word.Length);            

            for(int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append(word[i]);
            }

            return word.Equals(sb.ToString());
            
            //if (String.Compare(word, sb.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
            //    return true;
            //else
            //    return false;
        }

        public string ReverseWords(string str)
        {
            string[] words = str.Split(' ');
            string[] revWords = Array.Reverse(words);  // words.Reverse().ToArray();
            string result = string.Join(" ", revWords);
            return result;
        }
    }
}



