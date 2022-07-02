using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevelopmentInfo.Entities;
using System.Reflection;

namespace DevelopmentInfo.CodeSamples
{
    public sealed class Collections
    {
        public void EnumerableExtensions()
        {
            Console.WriteLine($"\nStarting method: {MethodBase.GetCurrentMethod().Name}()");

            // var names = new string[]{"house", "store", "bank"};  // Causes an InvalidOperationException
            // var names = new string[] {};                         // Causes a default (null) value to be returned
            var names = new string[] {"house"};                     // This works. Must be only one value in sequence
            var selectedName = names.SingleOrDefault();
            Console.WriteLine($"selectedName = {(String.IsNullOrEmpty(selectedName) ? "Default Value(null)" : selectedName)}");

            // int[] pageNumbers = { 77, 33 };                      // Causes a default (null) value to be returned
            // int[] pageNumbers = { 77 };                          // This works. Must be only one value in sequence
            int[] pageNumbers = {};                                 // This will cause default value 122 to display
            Console.WriteLine($"pageNumbers = {pageNumbers.DefaultIfEmpty(122).Single()}");

            // int[] pageNumbers2 = { };                            // Causes an ArgumentNullException. To avoid us SingleOrDefault.
            // int[] pageNumbers2 = {22, 56, 66 };                  // Causes an InvalidOperationException
            int[] pageNumbers2 = { 77 };                            // This works. Must be only one value in sequence
            
            //**********These lines are not working**************************************
            //Console.WriteLine($"pageNumbers = {pageNumbers2.Single()}");
            //Console.WriteLine($"Using Lambda: pageNumbers = {pageNumbers.Single(p => p == 77)}");
        }

        public void ListsInAction()
        {
            // Link list copying
            var myIntsSource = new List<int>() { -15, 0, 23, 24, 25, 26, 27, 28, 29, 75, 76, 100, 125, 5000 };

            var intArray = new int[myIntsSource.Count]; 
            myIntsSource.CopyTo(intArray);
            var myIntsTarget = new List<int>( myIntsSource);

            var dayValues = new List<string>() { "4", "7", "3", "8", "2", "5" };
            int total = dayValues.Sum((x) => Convert.ToInt32(x));
            ;
        }

        public void ArraysInAction()
        {
            // Sum an array of ints using the Sum LINQ extension method
            int[] someInts = {10, 20, 30, 40, 55, 60};
            int sum = someInts.Sum(); // or Sum(i => i);
            int sumSmall = someInts.Where(i => i < 30).Sum();  // sumSmall == 30

            // Test run the Sum method in both parallel and single core
            int[] arrayOfInts = Enumerable.Range(0, short.MaxValue).ToArray();

            var sw1 = new Stopwatch();
            sw1.Start();
            _ = arrayOfInts.AsParallel().Sum(i => i);       // Sum in parallel 
            sw1.Stop();
            
            var sw2 = new Stopwatch();
            sw2.Start();
            _ = arrayOfInts.Sum(i => i);                    // Sum on a single thread
            sw2.Stop();

            const int m = 10000;
            Console.WriteLine("\nMeasure time to sum as single thread and parallel operation");            
            Console.WriteLine($"Sum in parallel      SW1: {((double)(sw1.Elapsed.TotalMilliseconds * 1000000) / m).ToString("0.00 ns")}");
            Console.WriteLine($"Sum on single thread SW2: {((double)(sw2.Elapsed.TotalMilliseconds * 1000000) / m).ToString("0.00 ns")}");
            Console.Read();

            // Demo Average, Any, All
            double average = someInts.Average();
            bool anyInts = someInts.Any(i => i > 30);   // True if any of the elements are greater than 30
            bool allInts = someInts.All(i => i > 30);   // True if all the elements are greater than 30

            // Build a string from the values in a two dimensional array
            string[][] employees = new string[3][];
            employees[0] = new string[] { "1201", "Jim", "Team Leader" };
            employees[1] = new string[] { "1202", "Bob", "Developer" };
            employees[2] = new string[] { "1203", "Sue", "Designer" };
            
            var result = new StringBuilder();
            
            employees.ForEach(emp => 
                {
                    emp.ForEach(detail =>
                        {
                            result.Append(string.Format($"{detail}, "));
                        });
                }
            );

            result.Clear();
            employees.ForEach(emp =>
            {
                emp.ForEach(detail =>
                {
                    result.Append($"{detail}, ");
                });
            }
            );

            // Implemented above using extension methods and lambda.
            //foreach (var emp in employees)
            //{
            //    foreach (string detail in emp)
            //    {
            //        result.Append(string.Format("{0}, ", detail));
            //    }
            //}

            Console.WriteLine("Results from processing two dimensional array");
            Console.WriteLine($"Employee result01: {result.ToString()}");
            Console.WriteLine($"Employee result: {result.ToString().Remove(result.Length - 2)}"); // Removes trailing comma
            //Console.ReadLine();
        }

        public void DictionaryGeneric()
        {
            Console.WriteLine("Starting method: DictionaryGeneric()");
            var myDictionary = new Dictionary<string, string>(20)
            {
                // Overwrites if it already exists
                ["Key1"] = "Rock",
                ["Key2"] = "Paper",
                ["Key3"] = "Scissors"
            };

            // This will create a list of key\value pairs if one is desired.
            var items = myDictionary.ToList();

            foreach (KeyValuePair<string, string> keyVal in myDictionary)
            {
                Console.WriteLine($"Key: {keyVal.Key}  Value: {keyVal.Value}");
            }

            var gameValue = myDictionary
                .Where(i => i.Key == "Key1" || i.Key == "Key2")
                .Select(i => i.Value);

            foreach (var val in gameValue)
            {
                Console.WriteLine("Queried value from myDictionary: {val}");
            }
        }

        // Note: Use a linked list over a List when you plan on doing a lot of prepending or you somewhere 
        // have the reference of where you plan to insert the item. Just because you have to insert a lot 
        // of items it does not make it faster because searching the location where you will like to insert 
        // the item takes time.
        public void LinkedListClass()
        {
            Console.WriteLine("Starting method: LinkedListClass()");
            var todoList = new LinkedList<ToDoItem>();

            var i1 = new ToDoItem
            {
                Name = "Vehicle1", 
                Comment = "Should be done third"
            };
            var i2 = new ToDoItem
            {
                Name = "Vehicle2", 
                Comment = "Should be done first"
            };
            var i3 = new ToDoItem
            {
                Name = "Vehicle3", 
                Comment = "Should be done second"
            };
            var i4 = new ToDoItem
            {
                Name = "Vehicle4", 
                Comment = "Should be done last"
            };

            todoList.AddFirst(i1);
            todoList.AddFirst(i2);

            // Find i1 and place i3 before it
            var findThis = todoList.Find(i1);

            if (findThis != null)
            {
                todoList.AddBefore(findThis, i3);
            }

            // Find i1 and place i4 after it
            findThis = todoList.Find(i1);

            if (findThis != null)
            {
                todoList.AddAfter(findThis, i4);
            }

            Console.WriteLine("Display all items in todoList");

            foreach (var tdi in todoList)
            {
                Console.WriteLine("{tdi.Name} : {tdi.Comment}");
            }

            if (todoList.First.Next != null)
            {
                // Display information from the second node in the linked list.
                Console.WriteLine("todoList.First.Next.Value.Name == {todoList.First.Next.Value.Name}");
            }

            if (todoList.Last.Previous != null)
            {
                // Display information from the next to last node in the linked list.
                Console.WriteLine("todoList.Last.Previous.Value.Name == {todoList.Last.Previous.Value.Name}");
            }
        }

        public void LinqMultipleFromClausesExamined()
        {
            Console.WriteLine("Starting method: SelectManyExamined()");

            IEnumerable<int> values1 = Enumerable.Range(4, 3); // Values {4, 5, 6};
            IEnumerable<int> values2 = Enumerable.Range(7, 3); // Values {7, 8, 9};

            var result =  // A second from clause will result in the query being translated as a select many operation
                from item1 in values1  // Get an item from values1
                from item2 in values2  // For each item retrieved from values1 get all items from values2
                select item1 + item2;  // Add each item from values1 to all the items in values2

            //var result2 = 
            //      values1.SelectMany((i1, i2) =>() )


            foreach (var r in result)
            {
                Console.WriteLine($"r = {r}");
            }
            // The results will be the sums of (4,7 4,8, 4,9)  (5,7 5,8 5,9)  (6,7 6,8 6,9)

            string[] quotes =
            {
                "The motor bike is all that it is supposed to be",
                "The car is used to get to work in the morning"
            };

            var distictWords =
                (from sentence in quotes
                 from word in sentence.Split(' ')
                 select word).Distinct();

            // Note: If I used a Select I would get back two string arrays "The" and "The"
            // var distictWords = quotes.SelectMany(s => s.Split(' ')).Distinct();

            foreach (var distictWord in distictWords)
            {
                Console.Write($"{distictWord}");
            }

            Console.WriteLine();

            var pods = new List<Pod>            //() optional
            {
                new Pod {Values = new List<int> {30, 40, 50}},
                new Pod() {Values = new List<int>() {35, 40, 50}},
                new Pod() {Values = new List<int>() {30, 40, 50}}                
            };

            var totalValuesUsingFromFrom =
                (from p in pods
                 from v in p.Values
                 select v).Sum();

            var totalValuesUsingSelectMany = pods.SelectMany(p => p.Values).Sum();

            Console.WriteLine($"totalValuesUsingFromFrom = {totalValuesUsingFromFrom}");
            Console.WriteLine($"totalValuesUsingSelectMany = {totalValuesUsingSelectMany}");

            // This returns the sum of the values for the Pod whose first value is greater than 30.
            var totalOfValues01 = pods.Where(v => v.Values[0] > 30).SelectMany(v => v.Values).Sum();
            Console.WriteLine($"Sum of the values for the Pod whose first value is greater than 35 = {totalOfValues01}");

            var totalOfValues02 = pods.SelectMany(v => v.Values).Sum();
            Console.WriteLine($"Sum of all pod values is {totalOfValues02}");
        }

        public void LinqQueries()
        {
            Console.WriteLine("Starting method: LinqQueries()");

            // Query a List of order objects
            var orders = new List<Order> {
                         new Order {OrderId = 1, CustomerId = 86, Cost = 159.12},
                         new Order {OrderId = 2, CustomerId = 17, Cost = 18.50},
                         new Order {OrderId = 3, CustomerId = 93, Cost = 2.89}
                     };

            //IList<double> ordersFound = (from o in orders
            //                  where o.CustomerId > 84
            //                  select o.Cost).ToList();

            IList<double> ordersFound = orders.Where(o => o.CustomerId > 84)
                                        .Select(o => o.Cost)
                                        .ToList();

            foreach (var r in ordersFound)
            {
                Console.WriteLine("Cost: " + r.ToString());
            }
            
            // Query a List of vehicle addresses to get the value for a particular key
            var vehicleAddresses = new Dictionary<string, string>
            {
                {"vehicle1", "100.120.44.001"},
                {"vehicle2", "100.120.44.002"},
                {"vehicle3", "100.120.44.003"}
            };

            // Use query Syntax
            var vehiclesFound_1 = from v in vehicleAddresses
                                where v.Key.Contains("vehicle2")
                                select v.Value;

            Console.WriteLine($"vehiclesFound_1 value(1) = {vehiclesFound_1.ToArray().FirstOrDefault()}");
            Console.WriteLine($"vehiclesFound_1 value(2) = {vehiclesFound_1.FirstOrDefault()}");

            // Use a lambda expression to get the vehicle address. Also known as Method syntax
            var vehiclesFound_2 = vehicleAddresses.Where(v => v.Key.Contains("vehicle2")).Select(x => x.Value);
            Console.WriteLine($"vehiclesFound_2 value(1) = {vehiclesFound_2.ToArray().FirstOrDefault()}");
            Console.WriteLine($"vehiclesFound_2 value(2) = {vehiclesFound_2.FirstOrDefault()}");

            // FirstOrDefault() will not throw an exception while First will if no matching value is found
            var vehicleNotFound = vehicleAddresses.FirstOrDefault(kvp => kvp.Key.Contains("vehicleNotExists")).Value;
            
            Console.WriteLine($"vehicleNotExists = {(vehicleNotFound == null ? "null" : "vehicleNotFound")}");

            // Determine which people have pets that are all older than 5.
            var people = new List<Person>
                { new Person { LastName = "Haas",
                               Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
                                                  new Pet { Name="Boots", Age=14 },
                                                  new Pet { Name="Whiskers", Age=6 }}},
                  new Person { LastName = "Fakhouri",
                               Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
                  new Person { LastName = "Antebi",
                               Pets = new Pet[] { new Pet { Name = "Belle", Age = 8} }},
                  new Person { LastName = "Philips",
                               Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
                                                  new Pet { Name = "Rover", Age = 13}} }
                };

            var peopleWithPetsOlderthanFive = people.Where(p => p.Pets.Any(pet => pet.Age > 5))   // Any pet that meets the condition
                                                    .Select(p => p.LastName);

            //var peopleWithPetsOlderthanFive = from p in people                                  // All pets that meets the condition
            //    where p.Pets.All(pet => pet.Age > 5)
            //    select p.LastName;

            foreach (var name in peopleWithPetsOlderthanFive)            
                Console.WriteLine($"PeopleWithPets: {name}");

            // Gets the names of the pets with an age > 5
            //var PetsOlderthanFive = from p in people
            //                        from pt in p.Pets
            //                        where pt.Age > 5
            //                        select pt.Name;

            // Also gets the names of the pets with an age > 5
            var NamesOfPetsOlderthanFive = people.SelectMany(p => p.Pets).Where(pet => pet.Age > 5).Select(pet => pet.Name);

            foreach (var petName in NamesOfPetsOlderthanFive)
                Console.WriteLine($"Name of Pet older than 5: {petName}");

            // Returns all Pet objects that are in the list of persons named people
            var ManyPets = people.SelectMany(p => p.Pets);

            // Returns Pet objects in descending order by age
            var PetsOlderthanFive_ = people.SelectMany(p => p.Pets).Where(pet => pet.Age > 5).OrderByDescending(pet => pet.Age);

            // Not working example: Pets have not been selected before the where clause that tests the pet's age.
            //var PetsOlderthanFive_2 = people.Where(pet => pet.Age > 5).SelectMany(p => p.Pets).OrderByDescending(pet => pet.Age);
            
            //------------------------------------------------------------
            Pet[] pets = { new Pet { Name="Barley", Age=10 },
                           new Pet { Name="Boots", Age=4 },
                           new Pet { Name="Buthead", Age=6 } };

            // Determine whether all pet names in the array start with 'B'. 
            bool allStartWithB = pets.All(pet => pet.Name[0] == 'B');
            //bool allStartWithB = pets.All(pet => pet.Name.StartsWith("B"));

            if (allStartWithB)
                Console.WriteLine("All pets start with B");

            Console.WriteLine($"{(pets.All(pet => pet.Name.StartsWith("B")) ? "All pets start with B" : "All pets do not start with B")}");

            var result = $"{(pets.All(pet => pet.Name.StartsWith("B")) ? "All pets start with B" : "All pets do not start with B")}";

            // Create example from this:
            //var clientsWithEmails = activityEmails.Concat(tenantEmails).Where(e => e.HasEmails == "Yes").ToList();


            return;
        }
        
        public void NameValueCollectionClass()
        {
            Console.WriteLine("Starting method: NameValueCollectionClass()");

            const string name = "123.55.66.7";
            const string lat0 = "-180.3327", long0 = "68.9005";
            const string name1 = "123.55.66.8", lat1 = "-180.3328", long1 = "68.9006";
            const string name2 = "123.55.66.9", lat2 = "-180.3329", long2 = "68.9007";

            var nvc = new NameValueCollection()
            {
                {name, lat0},
                {name, long0},
                {name1, lat1},
                {name1, long1},
                {name2, lat2},
                {name2, long2},
                {name2, "ThirdValue"}
            };

            //nvc.Add(name, lat0);
            //nvc.Add(name, long0);
            //nvc.Add(name1, lat1);
            //nvc.Add(name1, long1);

            Console.WriteLine("Display all items in NameValueCollection");

            foreach (string myKey in nvc.AllKeys)
            {
                Console.WriteLine($"myKey is {myKey}");

                foreach (string value in nvc.GetValues(myKey))
                {
                    Console.WriteLine($"   Value is: {value}");
                }
            }

            var items = nvc.AllKeys.SelectMany(nvc.GetValues, (k, v) => new {key = k, value = v});
            foreach (var item in items)
                Console.WriteLine($"{item.key} {item.value}");
        }

        public void VariousCollections()
        {
            // string[] arrayOfStrings = new string[]{"Boat", "Car", "Incubator", "Mouse Trap", "bat"};

            string[] arrayOfStrings = { "Boat", "Car", "Incubator", "Mouse Trap", "bat" };

            // Generate a lookup structure where the lookup is based on the key length.
            ILookup<int, string> lookup = arrayOfStrings.ToLookup(item => item.Length);
            
            // Enumerate strings of length 3
            foreach(string item in lookup[3])
                Console.WriteLine($"Look up with value of 3 = {item}");

            // Enumerate groupings by length
            foreach (var grouping in lookup)
            {
                Console.WriteLine("Grouping:");
                foreach (string item in grouping)
                    Console.WriteLine(item);
            }
        }
    }
}
