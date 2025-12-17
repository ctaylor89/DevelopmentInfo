using DevelopmentInfo.Entities;
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
                Console.WriteLine($"{length}");
                return;
            }
            else if (length >= 1)
            {
                Console.WriteLine($"{length}");
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

        public IEnumerable<string> OpenOrSenior4(int[][] data) =>
            data.Select(d =>
                d[0] < 0 || d[1] < -2 || d[1] > 26
                    ? "Open"
                    : (d[0] >= 55 && d[1] > 7 ? "Senior" : "Open"));


        //---------------------------------------------------------------------
        // Accepts a string, and returns the same string with all even indexed characters in each word upper cased,
        // and all odd indexed characters in each word lower case.
        public string ToWeirdCase(string s)
        {
            var sb = new StringBuilder();

            foreach (var word in s.Split(' '))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (i % 2 == 0)
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
                    _ = i % 2 == 0 ? sb.Append(char.ToUpper(word[i])) : sb.Append(word[i]);
                }

                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
        //---------------------------------------------------------------------
        public int ConsonantCount(string str)
        {
            int countOut = 0;
            str = str.ToUpper().Trim();

            for (int i = 0; i < str.Length; i++)
            {
                int countCons = (from c in new char[] { 'A', 'E', 'I', 'O', 'U' }
                                 where c == str[i]
                                 select c).Count();

                if (countCons == 0)
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

            for (int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append(word[i]);
            }

            return word.Equals(sb.ToString());

            //if (String.Compare(word, sb.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
            //    return true;
            //else
            //    return false;
        }

        //---------------------------------------------------------------------
        public string ReverseWords(string str)
        {
            //string[] words = str.Split(' ').ToList<string>().Reverse();  // Cannot call str.Split(' ').Reverse() on the instance here but can below.
            List<string> wordList = str.Split(' ').ToList<string>();
            var result = String.Join(' ', wordList);

            //Array.Reverse(words);
            //return string.Join(" ", words);
            return result;
        }

        public string ReverseWords2(string str)
        {
            return string.Join(" ", str.Split(' ').Reverse());  // Not sure why I can call reverse on the Split here but not above.
        }

        public string ReverseLetters(string input)
        {
            char[] charArray = input.ToCharArray();

            int left = 0;
            int right = charArray.Length - 1;

            while (left < right)
            {
                char testChar = charArray[right];
                
                if (!char.IsDigit(charArray[right]))
                    //if (char.IsLetter(charArray[left]) && char.IsLetter(charArray[right]))
                {
                    // Swap letters
                    char temp = charArray[left];
                    charArray[left] = charArray[right];
                    charArray[right] = temp;

                    // Move pointers
                    left++;
                    right--;
                }
                else
                {
                    // Move pointers without swapping if not letters
                    //if (!char.IsLetter(charArray[left]))
                        left++;
                    //if (!char.IsLetter(charArray[right]))
                        right--;
                }
            }

            return new string(charArray);
        }
        //---------------------------------------------------------------------
        // Consider an array/list of sheep where some sheep may be missing from their place.We need a function that counts the
        // number of sheep present in the array (true means present).
        public int CountSheeps(bool[] sheeps)
        {
            
            //int sheepsPresent = sheepsPresent = sheeps.Where(s => s == true).Count();
            
            // AI
            int sheepsPresent = sheeps.Count(s => s == true);
            
            //sheepsPresent = (from s in sheeps
            //                 where s == true
            //                 select s).Count();

            //foreach (bool s in sheeps)
            //{
            //    if (s == true) sheepsPresent++;
            //}

            return sheepsPresent;
        }

        // Write a public static method "greet" that returns "hello world!"
        public static string Greet()
        {
            var statement = "hello world!";
            var reversedArray = new char[statement.Length];
            var sb = new StringBuilder();

            for (int st = statement.Length - 1, ra = 0; st >= 0; st--, ra++)
            {
                reversedArray[ra] = statement[st];
            }

            for (int i = statement.Length - 1; i >= 0; i--)
            {
                sb.Append(statement[i]);
            }

            // Why does this not work as expected. Nothing to do with this solution.
            var place = "My mouse on the hill next to yours";
            int loc = place.IndexOf("h");

            return statement;
        }

        // Write a function that will take the number of petals of each flower and return
        // true if one flower only has an odd count of pedals or false if not the case.
        public static bool IsInLove(int flower1, int flower2)
        {
            // My answer
            return (flower1 % 2 == 0 && flower2 % 2 != 0) || (flower1 % 2 != 0 && flower2 % 2 == 0) ? true : false;

            // Better Answer
            // return flower1 % 2 != flower2 % 2;
        }

        // Rearrange the digits to create the highest possible number.
        public static int DescendingOrder(int num)
        {
            var numStr = num.ToString();
            var numArray = new int[numStr.ToString().Length];

            for (int i = 0; i < numStr.Length; i++)
                numArray[i] = int.Parse(numStr[i].ToString());

            Array.Sort(numArray);
            Array.Reverse(numArray);

            var sb = new StringBuilder();
            Array.ForEach(numArray, n => sb.Append(n.ToString()));           
                        
            return int.Parse(sb.ToString());

            // Better, Uses OrderByDescending extension method on a string.
            // Converts input num to a string. A single string param to Concat will return a string. 
            // return int.Parse( string.Concat(num.ToString().OrderByDescending(x => x)) );
        }

        public int GetSum(int a, int b)
        {
            int sum = 0;

            if (b > a)
                for (int i = a; i <= b; i++)
                    sum += i;
            else
                for (int i = a; i >= b; i--)
                    sum += i;
            return sum;
        }

        public bool ValidatePin(string pin)
        {
            bool isValidPin = true;

            if (pin.Length == 4 || pin.Length == 6)
            {                
                for (int i = 0; i < pin.Length; i++)
                {
                    if (!Char.IsDigit(pin[i]))
                    {
                        isValidPin = false;
                        break;
                    }                    
                }
            }
            else
                isValidPin = false;

            return isValidPin;

            // Better using the 'All' extension method. Pin type is a stringl.            // return pin.All(n => Char.IsDigit(n)) && (pin.Length == 4 || pin.Length == 6);
        }

        public int MsSinceMidnight(int h, int m, int s)
        {
            int msTotal = -1;

            if (h >= 0 && h <= 23 && m >= 0 && m <= 59 && s >= 0 && s <= 59)
                msTotal = Convert.ToInt32(new TimeSpan(h, m, s).TotalMilliseconds);                

            return msTotal;
        }

        // Given a list of integers, determine whether the sum of its elements is odd or even.
        // Give your answer as a string matching "odd" or "even".
        // If the input array is empty consider it as: [0] (array with a zero)
        public string OddOrEvenSum01(int[] array)
        {
            int sumVal = 0;

            if (array.Length != 0)
            {
                sumVal = array.Sum();

                if (sumVal % 2 == 0)
                    return "even";
                else
                    return "odd";
            }
            else
                return "even";
        }
        // Or
        public string OddOrEvenSum(int[] array)
        {
            return array.Sum() % 2 == 0 ? "even" : "odd";
        }
        // Another way though not better
        public static string OddOrEven(int[] a) => a.Sum() % 2 == 0 ? "even" : "odd";

        // Input a string of words. Reversed the letters in each word, but keep the words in the same order.
        public string ReplaceWords(string str)
        {
            var sb = new StringBuilder();
            var arr = str.Split(' ').ToArray();

            foreach (string s in arr)
            {
                for(int n = s.Length -1; n >= 0; n--)
                {
                    sb.Append(s[n]);
                }

                sb.Append(' ');
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
        // Or
        // return string.Join(" ", str.Split(' ').Select(i => new string (i.Reverse().ToArray())));

        // You are provided with a list of integer pairs. Each pair represent the number of people that get on the
        // bus(the first item) and the number of people that get off the bus(the second item) at a bus stop.
        // Your task is to return the number of people who are still on the bus after the last bus stop (after the last array)
        public static int NumberOfPeopleOnBus(List<int[]> peopleListInOut)
        {
            int total = 0;
            peopleListInOut.ForEach((x) => total += x[0] - x[1]);
            return total;
        }
        // Or                                  On Bus - Off Buss
        // return peopleListInOut.Sum(Item => Item[0] - Item[1]);

        // Given an integer or a floating-point number, find its opposite.
        public int Opposite(int number)
        {
            //if (Math.Sign(number) < 0)
            //    return Math.Abs(number);
            //else
            //    return number - (number * 2);

            return Math.Sign(number) < 0 ? Math.Abs(number) : number - (number * 2);
        }

        public string Smash(string[] words)
        {
            // This works:
            //var sb = new StringBuilder();
            //Array.ForEach(words, w => sb.Append(w + " "));
            //var result = sb.ToString().TrimEnd();

            var result = String.Join(" ", words);

            return result;

            // Better: return
        }

        // Return the number(count) of vowels in the given string. Test for letters a, e, i, o, u as vowels for this
        // Kata(but not y). The input string will only consist of lower case letters and/or spaces.
        public int GetVowelCount(string str)
        {
            int vowelCount = 0;           
            
            for (int i = 0; i < str.Length; i++)
                if ("aeiou".Contains(str[i])) vowelCount++;

            return vowelCount;
            
            // Better: Count is an ext method that returns how many elements match the condition.
            //return str.Count(i => "aeiou".Contains(i));
        }

        // Find items in new list that are not in old list
        public string[] GetItemsNotInOriginalList(string[] newList, string[] oldList)
        {
            var newItems = new List<string>();
                                               
            for(int i = 0; i < newList.Length; i++)
            {
                if (!oldList.Contains(newList[i]))
                {
                    newItems.Add(newList[i]);
                }
            }

            return newItems.ToArray();
        }

        //for(int o = 0; o < oldList.Length; o++)
        //{
        //    if (newList[i] == oldList[o])
        //    {
        //        break;  
        //    }

        //    foundNewItem = true;
        //}

        //newItems.Add(newList[i]);

        public int TestThis() 
        {
            int[] numbers = { 1, 3, 5, 7, 9, 11 };
            

            return 0; 
        }
    }
}



























