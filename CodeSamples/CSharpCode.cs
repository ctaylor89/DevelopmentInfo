using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentInfo.Entities;
using System.Runtime.CompilerServices;
using System.IO;
using System.Diagnostics;  // For the debugging attributes

namespace DevelopmentInfo.CodeSamples
{
    public class CSharpCode
    {
        // Delegate with parameters practice
        delegate int DelegateGetNewNumber(int val);
        delegate int DelegateMakeNumber(int val);
        delegate bool DelegateBiggerThan(int n, string s);
        enum Cars { Mustang = 1, Corvette = 2, F150 = 3 };

        /// <summary>
        /// Created in the conflict_branch
        /// </summary>
        public string GetFished()
        {
            Console.WriteLine("Starting method: GetFished()");
            return "Fished";
        }

        public void CSharpCoding()
        {            
            Console.WriteLine("Starting method: CSharp3()  conflict_branch changed 2");
            Console.WriteLine("Starting method: CSharp3()  conflict_branch Added this line");

            var listIntegers = new List<int>();
            listIntegers.AddRange(new int[] { 20, 1, 4, 8, 9, 44, 5, 11, 66, 222, 300, 449, 509, 519 });
            var count = listIntegers.Count;
            Console.WriteLine("Count of listIntegers: {0}", count);


            // Find all even numbers in a list of numbers            
            List<int> evenNumbers = listIntegers.FindAll(i => (i % 2) == 0);

            Console.WriteLine("\nEven number results:");

            evenNumbers.ForEach(n => Console.WriteLine($"{n}"));

            var largeEvenNumbers = evenNumbers.Where(en => en > 100);

            Console.WriteLine("\nLarge Even Number results:");

            foreach (var L in largeEvenNumbers)
                Console.WriteLine($"{L}");            
            
            int[] myNums = { 12, 5, 11, 2, 44, 30, 1, 7, 5, 4 };
            
            IEnumerable<int> Bs2 = myNums.Where(n => n < 5);
            // Or older way
            IEnumerable<int> numbersLessThan5 = myNums.Where<int>(delegate(int n) { return n < 5; });

            Console.WriteLine("Start test: Numbers Less Than 5");
            foreach (var n in numbersLessThan5)  
                Console.WriteLine($"{n}");
                        
            // Older way: Call TryGetNewNum passing in an annonymous delegate as a parameter
            int ret = TryGetNewNum(delegate(int n) { int i = n * n; return i; });

            // Call TryGetNewNum passing in a Lambda Method as a parameter
            int ret2 = TryGetNewNum(n => n * n);

            // Assigning a method implementation to a variable that is a particular type of function signature
            DelegateMakeNumber AddNumberUsingDelegate = delegate(int n) { n += 5; return n; };
            DelegateMakeNumber AddNumberUsingLambda = n => n += 50;

            int delegateAnswer = AddNumberUsingDelegate(23);
            int lambdaAnswer   = AddNumberUsingLambda(23);

            // Two arguments, parentheses are required
            DelegateBiggerThan dbt = (nx, s) => s.Length > nx;
            bool isStringBigger = dbt(10, "012345678");

            // An annonymous object initialized. It is not based on any declared type.
            var newMonkey = new { Name = "Ted", Age = 98, Color = "blue", BirthDate = new DateTime(2000, 2, 14) };
            
            // ******************************************************************************
            // Type inference
            var what = DateTime.Now;
            var day = what.Day;
            var x = 5;
            var whatIs = x < 9 ? 14 : 22.8;   // Returns a double either way. Return value is inferred to be a double.
            string isThis = whatIs.GetType().Name;

            // Interface sample isx5
            var preferCats = true;
            // IAnimal pet = preferCats ? (IAnimal)(new Cat()) : (IAnimal)(new Dog());
            IAnimal pet = preferCats ? new Cat() as IAnimal : new Dog() as IAnimal;

            // Tail is a public property of Cat. Cannot access through IAnimal in these two scenarios
            //pet.Tail = String.Empty;
            //if(pet.GetType() == typeof(Cat)) pet.Tail = String.Empty;

            var sounds = new List<string>();
            sounds.AddRange(pet.GetCommunicationMethod());
            sounds.ForEach(s => Console.WriteLine(s));

            // Annonymous type making use of object initializers and type inference.
            var vehicle = new { Name = "Car1", HorsePwr = 345, Purchasedate = new DateTime(2011, 03, 03) };
            string vehicleType = vehicle.GetType().Name; // vehType is <>f__AnonymousType2`3

            // SampleX4
            // Prepare sample data
            var nameData = new string[] { "Steve", "Jimmy", "Celine", "Arnold" };

            // Transform onto an enumerable of anonymously typed objects 
            var people = nameData.Where(str => str != "Jimmy") // Filter out Jimmy 
                                 .Select(str => new            // Project on to anonymous type 
                                 {          
                                     Name = str,
                                     LettersInName = str.Length,
                                     IsLongName = (str.Length > 5)
                                 });

            Console.WriteLine("Projection Example");

            // people is an annonymous type
            people.ToArray().ToList().ForEach(s => {
                var output = string.Format($"{s.Name} has {s.LettersInName} letters in their name. " +
                                $"{(s.IsLongName ? "That's long! " : "That's short")}"
                    );
                Console.WriteLine("{0}", output);
            });

            //----------------------------------------------------------------------------------------
            var teamMembers = new string[] { "Bob Statham", "Cecil Smith", "Donna Cat", "Shirley Grippon", "Ronald Trip" };

            var teamPeople = teamMembers.Where(tm => string.CompareOrdinal(tm, "Ronald") != 0)
                .Select(m => new
                {
                    FullName = m,
                    NameLength = m.Length,
                    FirstName = m.Substring(0, m.IndexOf(' ')),
                    LastName = m.Substring((m.IndexOf(' ') + 1))
                });

            foreach(var tp in teamPeople)
            {
                Console.WriteLine($"FullName: {tp.FullName}  NameLengh: {tp.NameLength}" +
                    $"First Name: {tp.FirstName}  LastName: {tp.LastName}");
            }
            //---
            // Reverse a string
            var title = "The best of times is now upon us";
            var titleRev = new StringBuilder(title.Length);

            try
            {
                for (int i = title.Length - 1; i >= 0; i--)
                {
                    titleRev.Append(title[i]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Finally statement ran.");
            }

            Console.WriteLine($"title Reversed: {titleRev}");
            //----------------------------------------------------------------------------------------
            Console.WriteLine();

            // Or Retrieve data from the enumerable 
            foreach (var person in people)
            {
                var output = string.Format($"{person.Name} has {person.LettersInName} letters in their name.");
                Console.WriteLine(person.IsLongName ? "That' s long! " : "That's short");
                Console.WriteLine(output);
            }

            var myCat = new Cat() { Feet = 4, Tail = "one" };
            var myPet = new { myCat.Feet, myCat.Tail };

            // Callback Functions Demonstration
            const int startingValue = 10;
            const int interationCount = 5;

            int callBackResult = IncrementCallback(startingValue, interationCount);
            callBackResult = MultiplyCallback(startingValue, interationCount);
            Console.WriteLine("MultiplyCallback demonstration. Result = {0}", callBackResult);

            // Using an object intitializer and an array initializer. Works only for public properties.
            Person personToInit = null;
            personToInit = new Person { LastName = "Robertson", Pets = new Pet[2] { new Pet { Name = "Sam", Age = 4 }, new Pet { Name = "Radar", Age = 6 }}};

            LogMessage("Log this message using new C# 5.0 attributes");

            // Some string practice
            string s1 = "MyString";
            string result = !string.IsNullOrEmpty(s1)? s1: "default";

            object box1 = null;
            object box2 = new object();
            object box3 = box1 ?? box2;     // null-coalescing operator 
            //object box4 = box1 ??= box2;  // null-coalescing assignment operator is only avaiable in language version 8 
                                            // To use Null-coalescing assignment operator ??=, you’ll need to set up your machine to run .NET Core

            int valueToBox  = 100;
            object valueBoxed = valueToBox;

            if(valueBoxed.GetType() == typeof(int))
            {
                int valueUnboxed = (int)valueBoxed;
            }

            // Conversion 
            Console.WriteLine("Attempt to make conversion from string to money");
            decimal money = 50;
            //string uservalue = "10B.2";   // This value will cause a format exception
            string uservalue = "108.2";

            try
            {
                money = Convert.ToDecimal(uservalue);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Unable to make conversion to money: {0}", fe.Message);
            }

            Console.WriteLine($"money: {money}");

            // Or even better because it prevents an exception from being thrown.
            bool conversionWorked = decimal.TryParse(uservalue, out money);

            // Object Initializer example. Optional call to the constructor
            Pod initPod = new Pod() { Id = 300, Name = "Sam Pod", Qty = 29, StartDate = DateTime.Now, Price = 3.55M, Size = 4, Values = new List<int>()};

            // Path class - the second path is absolute, so the first one will be ignored.             
            string path11 = "c:\\DatumSuite\\Config";
            string path12 = "\\ctaylor";

            string resultPath = Path.Combine(path11, path12);
            Console.WriteLine("resultPath is: {0}", resultPath);

            string path1 = "c:\\temp";
            string path2 = "subdir\\file.txt";
            string path3 = "c:\\temp.txt";
            string path4 = "c:^*&)(_=@#'\\^&#2.*(.txt";
            string path5 = "";
            string path6 = null;

            CombinePaths(path1, path2);
            CombinePaths(path1, path3);
            CombinePaths(path3, path2);
            CombinePaths(path4, path2);
            CombinePaths(path5, path2);
            CombinePaths(path6, path2);
            CombinePaths(path11, path12);

            string inputFile = @"C:\DatumSuite\ICMA RC\Dev Test\Job_3d91cb3b-efd1-4175-b675-40606ab7242a\Deflate\Input\DeflateFile.gz";
            // Get the path without the file name
            int lastSlashLocation = inputFile.LastIndexOf(@"\");
            inputFile = inputFile.Remove(lastSlashLocation);

            //-----------------------------
            // enums

            // Already defined in this class: enum Cars{Mustang = 1, Corvette = 2, F150 = 3};
            int selectedCar = 1;
            string firstCar = Enum.GetName(typeof(Cars), selectedCar);
            string secondCar = Enum.GetName(typeof(Cars), 2);
        }

        private static void CombinePaths(string p1, string p2)
        {
            try
            {
                Console.WriteLine($"When you combine '{p1}' and '{p2}' the result is: {(Path.Combine(p1, p2))}");
            }
            catch (Exception e)
            {
                if (p1 == null) p1 = "null";
                if (p2 == null) p2 = "null";
                Console.WriteLine($"You cannot combine '{p1}' and '{p2}' because: {Environment.NewLine}{e.Message}");
            }

            Console.WriteLine();
        }
        // Tests the passing of value and ref types using ref and out keywords
        // [Obsolete]
        // [Obsolete("Will cause a compiler error", true)]
        [Obsolete("CT: Will cause a compiler Warning. Using Obsolete attribute")]
        public void ParamPassingTest()
        {
            Console.WriteLine("Starting method: ParamPassingTest()");
            
            // Passing value types as ref and out
            int valueOut = 200; // Initialization is optional here
            int valueRef = 0x300;
            PassInValueWithAnOutParam(out valueOut);  // Compiler error if param not assigned in method, even if it was already initialized in the calling method
            PassInValueWithRefParam(ref valueRef);

            // Do not have to initialize kittyAsOut before passing to to method
            Cat kittyAsOut; // Initialization is optional here
            PassInClassWithTheOutParam(out kittyAsOut);  // Compiler error if param not initialized in method, even if it was already initialized in calling method.
                                                         // Making an assignment to one of it's properties does not satisfy the requirement.
            
            // Changes the properties of the passed in object
            var kittyAsRef1 = new Cat{Feet = 4, Name = "kittyOrig", Tail = "long"};
            PassInClassWithRefParam(ref kittyAsRef1);

            // Changes the properties of the passed in object
            var kittyAsRef2 = new Cat{Feet = 4, Name = "kittyOrig", Tail = "long"};
            PassInClassParam(kittyAsRef2);

            // Passes in the address that kittyAsRef contains that points to a class(thats on the heap). Assigns it to a variable that is local to the called method
            var kittyAsRef3 = new Cat { Feet = 4, Name = "kittyOrig", Tail = "long" };
            PassInClassParam2(kittyAsRef3);

            // Passes in the address of the class name to a variable that is local to the called method. Similar to **Cat in C++.
            var kittyAsRef4 = new Cat { Feet = 4, Name = "kittyOrig", Tail = "long" };
            PassInClassWithRefParam2(ref kittyAsRef4);

            var titleOne = "titleOne";  // ref types
            var titleTwo = "titleTwo";
            // This will not affect the original variables
            SwapStringsAttempt(titleOne, titleTwo);
            // This will affect the original variables
            SwapStrings(ref titleOne, ref titleTwo);

            // Assign a reference to a reference type test
            var dogs = new List<Dog>();
            var dog1 = new Dog
            {
                Name = "dog1.Name = Herman",
                Feet = 4
            };
            
            dogs.Add(dog1);

            // Assign instance to another. Both of these variables will point to the same object on the heap.
            var dog2 = dog1;
            dogs.Add(dog2);

            // Create a new instance and assign the value "Feet"
            var dog3 = new Dog
            {
                Name = "dog3.Name = Alfy",
                Feet = dog1.Feet
            };
            
            dogs.Add(dog3);

            // Change value in dog1 after adding dogs to list
            dog1.Feet += 2;                         // This results in dog1 and dog2 having 6 feet
            dog2.Name = "dog2.Name = Bishop";       // This results in dog1 and dog2 having having the name "dog2.Name = Bishop"

            // Test if change in dog1's value affects both dogs in list
            foreach (var dog in dogs)
            {
                Console.WriteLine($"{dog.Name} has {dog.Feet} feet"); 
            }
        }
        
        // Use a callback function that increments inputValue the number of iterationCount
        // [Obsolete("Will cause a compiler error", true)]
        [Obsolete("Will cause a compiler Warning. CT Special")]
        private int IncrementCallback(int inputValue, int iterationCount)
        {
            int result = inputValue;

            if (iterationCount > 0)
            {
                iterationCount--;
                result = IncrementCallback(result += inputValue, iterationCount);
            }

            return result;
        }

        // Use a callback function to find the product of inputValue * iterationCount
        private int MultiplyCallback(int inputValue, int iterationCount)
        {
            int result = inputValue;

            if (iterationCount > 0)
            {
                iterationCount--;
                result += MultiplyCallback(inputValue, iterationCount);
            }

            return result;
        }

        private int TryGetNewNum(DelegateGetNewNumber getNewNum)
        {
            int result = getNewNum(5);
            return result;
        }

        // Using the out param forces the method to have to init the param
        private void PassInValueWithAnOutParam(out int value)
        {
            value = 0x600; // Compiler error if param not assigned in method, even if it was already the initialized in calling method
        }
        
        private void PassInValueWithRefParam(ref int value)
        {
            value = 0x400;
        }
        
        private void PassInClassWithTheOutParam(out Cat value)
        {
            // value.Feet = 3; // Can not do this
            value = new Cat() { Feet = 4 };
            // value = null; Can legally do this because an assignment is still being made.
        }
        
        private void PassInClassWithRefParam(ref Cat kitty)
        {
            kitty.Feet = 8; // This change affects the passed in object
        }

        private void PassInClassParam(Cat kitty)
        {
            kitty.Feet = 10; // This change affects the passed in object
        }

        private void PassInClassParam2(Cat kitty) // Param kitty is the address of the value and a local variable to the this method.
        {            
            kitty.Name = "Hal"; // This change affects the original element
            kitty = new Cat{Feet = 7, Name = "Bob", Tail = "Stump"}; // This change is local only****
            kitty.Feet = 500;
        }

        private void PassInClassWithRefParam2(ref Cat kitty) // Param is the address of where kitty stores the address of the value.
        {
            //Note: Passed in a ref to the param kitty.
            // This change affects the original element by assigning a new object to it
            kitty = new Cat { Feet = 20, Name = "Bobby", Tail = "Cut" };
        }

        private void SwapStringsAttempt(string titleOne, string titleTwo)
        {
            // This will not change the original variable because it creates a new string
            titleOne = "TitleChangedInFunction";
            
            // This swap will not change the original variables passed in to the function because they are local copies of the addresses.
            string temp = titleOne;
            titleOne = titleTwo;
            titleTwo = temp;
        }

        private void SwapStrings(ref string titleOne, ref string titleTwo)
        {
            // This swap will change the original variables passed in to the function. The variables are addresses of the string names in the calling method.
            string temp = titleOne;
            titleOne = titleTwo;
            titleTwo = temp;
        }

        // Uses the new C# 5.0 attributes for logging information
        public void LogMessage(string message,
                            [CallerMemberName] string memberName = "",
                            [CallerFilePath] string sourceFilePath = "",
                            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Trace.WriteLine("message: " + message);
            Trace.WriteLine("member name: " + memberName);
            Trace.WriteLine("source file path: " + sourceFilePath);
            Trace.WriteLine("source line number: " + sourceLineNumber);
            
            Console.WriteLine($"message: {message}");
            Console.WriteLine($"member name: {memberName}");
            Console.WriteLine($"source file path: {sourceFilePath}");
            Console.WriteLine($"source line number: {sourceLineNumber}");
        }
    }
}
