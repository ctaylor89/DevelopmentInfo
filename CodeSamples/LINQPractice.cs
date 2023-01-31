// Samples from MS located here: Dropbox\_samples\C# Samples\LinqSamples\101 LINQ Samples
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DevelopmentInfo.Entities;
using System.IO;

namespace DevelopmentInfo.CodeSamples
{
    public class LINQPractice
    {
        List<Pod> Podlist = new List<Pod>();
        List<PodInfoItem> PodInfolist = new List<PodInfoItem>();
        List<string> UserNames = new List<string>();

        private const int PodCount = 5;

        public LINQPractice()
        {
            GeneratePodlist();
            GenerateStringList();
        }

        private void GenerateStringList()
        {
            UserNames = new List<string>
            {
                "Zipper",
                "Lions Mouth",
                "Target",
                "BedPan",
                "SlamHead",
                "CartWheel",
                "AtHere",
                "ShipBuilder",
                "ShipCaptain"
            };
        }

        public void RunLinkQuerys()
        {
            Console.WriteLine("\nPractice Area");

            //---------------- Start Practice ---------------------------------------
            // Select annonymous object for each pod that has a values count > 3
            var podSet = (from p in Podlist
                         where p.Values.Count > 3
                         select new
                         {
                             Name = p.Name,
                             ValCount = p.Values.Count
                         }).ToList();

            var podSet2x = Podlist.Where(p => p.Values.Count > 3).Select(p => new {Name = p.Name, ValCount = p.Values.Count});

            podSet.ForEach(p => Console.WriteLine("\nPod Name: " + p.Name + " Val Count: " + p.ValCount));
            podSet2x.ForEach(p => Console.WriteLine("\nPod Name: " + p.Name + " Val Count: " + p.ValCount));

            // Select an array of integers
            int[] podIds = (from p in Podlist
                            where p.Id < 3
                            select p.Id).ToArray<int>();
            
            // Select the Pod values collection items using comprehension query
            List<int> intValues = (from p in Podlist
                                   from v in p.Values
                                   where v < 80
                                   select(v)).ToList();
            
            // Select the Pod values collection items using lambda query
            var intValues2 = (Podlist.SelectMany((p) => p.Values).Where(v => v < 80)).ToList();


            ;
            //---------------- End Practice ---------------------------------------















            // --------------------------------------
            // Create a list of annonymous objects
            var XpodList = (from p in Podlist
                            where p.Price > 0.5m
                            orderby p.Price
                            select new
                            {
                                PodName = p.Name,
                                Quantity = p.Qty.DoubleIt(),
                                MyPrice = p.Price,
                                DuckWad = p.Name
                            }).ToList();
            // --------------------------------------
            var XpodSubset = from p in Podlist
                            where p.Price > 0.5m && p.Name.StartsWith("A")
                            orderby p.Price
                            select new
                            {
                                PodName = p.Name,
                                Quantity = p.Qty,
                                MyPrice = p.Price,
                                DoubleQty = p.Qty.DoubleIt()
                            };

            Console.WriteLine("\nResults from XpodSubset");
            XpodSubset.ForEach(xps => Console.WriteLine($"PodName: {xps.PodName}  Quantity: {xps.Quantity}  MyPrice: {xps.MyPrice}"));
            
            var podSubset = Podlist.Where(p => p.Price > 0.05M)
                                    .OrderBy(p => p.Name)
                                    .Select(n => new { PodName = n.Name, Quantity = n.Qty.DoubleIt(), MyPrice = n.Price });

            Console.WriteLine("\nResults from podSubset");
            podSubset.ForEach(p => Console.WriteLine("Pod Name = {0}  Qty = {1}  Price = {2:0.00}", p.PodName, p.Quantity, p.MyPrice));

            // --------------------------------------
            var PodsStartWithR = Podlist.Where(p => p.Name.StartsWith("r", StringComparison.OrdinalIgnoreCase))
                                                     .OrderBy(p => p.Name)
                                                     .Select(t => new
                                                     {
                                                        PName = t.Name,
                                                        Quantity = t.Qty.DoubleIt()
                                                     });

            Console.WriteLine("\nResults from PodsStartWithR");
            PodsStartWithR.ForEach(p => Console.WriteLine($"+\tName: {p.PName}\tQuantity: {p.Quantity}"));
            
            // --------------------------------------
            var windowFilePaths = Directory.GetFiles(@"C:\windows", "*.log", SearchOption.TopDirectoryOnly)
                // .Where(f => Path.GetFileName(f).StartsWith("D", StringComparison.OrdinalIgnoreCase));
                               .Where(f => Path.GetFileName(f)[0] == 'D');

            Console.WriteLine("\nResults from Directory.GetFiles");
            windowFilePaths.ForEach(f => Console.WriteLine("FileName: {0}", f)); 

            // --------------------------------------
            // Compound From Clause
            // Returns an annonymous object for each pod value that has a value > 55. This results in duplicate 
            // pod objects being returned if the pod has multipe values that meet the criteria.
            var XpodSubset2 = from p in Podlist
                              from v in p.Values    // Inner sequence of values
                              where v < 55
                              orderby p.Name descending
                              select new            // Project a new object for each value
                              {
                                PodName = p.Name,
                                Quantity = p.Qty.DoubleIt(),
                                MyPrice = p.Price,
                                Value = v
                              };
           
            Console.WriteLine("\nResults from compound from clause");
            XpodSubset2.ForEach(p => Console.WriteLine("Pod Name = {0}   Qty = {1}   Price = {2:0.00}  Value = {3}", p.PodName, p.Quantity, p.MyPrice, p.Value));

            // ---- Same as above method but as a lambda. Projection is done before the where method

            var XpodSubset400 = Podlist.SelectMany(p => p.Values, (p, val) => new { PodName = p.Name, Quantity = p.Qty.DoubleIt(), MyPrice = p.Price, Value = val })
                                       .Where(pv => pv.Value < 55)
                                       .OrderByDescending(p => p.PodName);

            Console.WriteLine("\nResults from SelectMany projection clause");
            XpodSubset400.ForEach(ap => Console.WriteLine("Pod Name = {0}   Qty = {1}   Price = {2:0.00}  Value = {3}", ap.PodName, ap.Quantity, ap.MyPrice, ap.Value));

            // --------------------------------------
            // Returns the inner sequence of values that is in each pod.
            var XpodValues = Podlist.SelectMany(p => p.Values);

            Console.WriteLine("\nResults from SelectMany clause");
            XpodValues.ForEach(v => Console.WriteLine("Pod Value = {0}", v));

            // --------------------------------------
            // Performs an inner join using expression syntax
            var XpodJoinSet1 = from p in Podlist
                               where p.Price > 1.00M
                               join pinfo in PodInfolist on p.Id equals pinfo.PodId
                               select new
                               {
                                   PodInfoId = pinfo.Id,
                                   PodId = p.Id,
                                   PodName = p.Name,
                                   ManufactureDate = pinfo.ManufactoringDate.ToString()
                               };

            Console.WriteLine("*** 1) Joining PodList items to PodInfoList items. Annonymous Projection ***");
            XpodJoinSet1.ForEach(pi => Console.WriteLine("PodInfoId: {0}  PodName: {1}  PodId: {2}  MFDate: {3}", pi.PodInfoId, pi.PodName, pi.PodId, pi.ManufactureDate));

            // --------------------------------------
            // Performs an inner join same as above using Lambda syntax
            var XpodJoinSet3 = Podlist.Where(p => p.Price > 1.00M)
                                        .Join(PodInfolist,          // Inner sequence
                                            p => p.Id,              // Outer Key Selector
                                            pinfo => pinfo.PodId,   // Inner Key Selector
                                        (p, pinfo) => new           // Result projector
                                        {
                                            PodInfoId = pinfo.Id,
                                            PodId = p.Id,
                                            PodName = p.Name,
                                            ManufactureDate = pinfo.ManufactoringDate.ToString()
                                        });

            Console.WriteLine("*** 2) Joining PodList items to PodInfoList items. Annonymous Projection ***");
            XpodJoinSet1.ForEach(pi => Console.WriteLine("PodInfoId: {0}  PodName: {1}  PodId: {2}  MFDate: {3}", pi.PodInfoId, pi.PodName, pi.PodId, pi.ManufactureDate));

            // --------------------------------------
            // Get a set of pinfo objects for each pod in podlist where the pod price is greater than one.
            IEnumerable<PodInfoItem> XpodJoinSet2 = from p in Podlist
                                                    where p.Price > 1.00M
                                                    join pinfo in PodInfolist on p.Id equals pinfo.PodId
                                                    select pinfo;

            Console.WriteLine("*** Joining PodList items to PodInfoList items ***");
            XpodJoinSet1.ForEach(pi => Console.WriteLine("PodInfoId: {0}  PodId: {1}  MFDate: {2}", pi.PodInfoId, pi.PodId, pi.ManufactureDate));

            // --------------------------------------
            var XpodJoinSet4 = from p in Podlist
                               join pinfo in PodInfolist on p.Id equals pinfo.PodId
                                  into pinfo2
                               select new
                               {
                                   PodInfoId = pinfo2.FirstOrDefault().Id,
                                   PodId = p.Id,
                                   PodName = p.Name,
                                   ManufactureDate = pinfo2.FirstOrDefault().ManufactoringDate.ToString()
                               };

            Console.WriteLine("*** 1) Joining PodList items to PodInfoList items. Annonymous Projection ***");
            XpodJoinSet1.ForEach(pi => Console.WriteLine("PodInfoId: {0}  PodName: {1}  PodId: {2}  MFDate: {3}", pi.PodInfoId, pi.PodName, pi.PodId, pi.ManufactureDate));

            // --------------------------------------
            Pod XpodFirstOrDefault = (from p in Podlist
                                      where p.Id > 5
                                      select p).FirstOrDefault();
            // select p).SingleOrDefault();   // Throws a System.InvalidOperationException because there are more than one result.

            //Pod XpodFirstOrDefault2 = Podlist.Where(p => p.Id > 5).FirstOrDefault();  // Where method is not necassary
               //Or
            Pod XpodFirstOrDefault2 = Podlist.FirstOrDefault(p => p.Id > 5);

            Console.WriteLine(XpodFirstOrDefault2 != null ? $"XpodFirstOrDefault2.Id = {XpodFirstOrDefault2.Id}\n" : $"Result is null");

            var nums = new int[] { 100, 200, 300 };
            int firstResult = nums.FirstOrDefault(n => n > 300);    // Returns a default value of 0
            Console.WriteLine($"firstResult: {firstResult}");

            var users = UserNames.FirstOrDefault(u => u.StartsWith("Ship")); // Return first one found out of two possibilities
                                                                             // Returns null if no result. String is an object

            // --------------------------------------
            IEnumerable<Pod> pods = from p in Podlist
                                    let lowercaseName = p.Name.ToLower()    // lowercaseName becomes an alias for p.Name.ToLower()
                                    where lowercaseName.StartsWith(lowercaseName.Substring(lowercaseName.Length - 1))
                                    select p;
            
            pods.ForEach(p => Console.WriteLine("Pod Name where start char = end char: {0}\n", p.Name));

            // --------------------------------------
            // Group pods based on the first letter in the pod's name
            var groupedPods = from pod in Podlist
                              group pod by pod.Name[0] into letterGroup
                              orderby letterGroup.Key ascending
                              select letterGroup; 

            groupedPods.ForEach(group =>                                    // Each grouping
            {
                Console.WriteLine("Group Key: {0}", group.Key);
                group.ForEach(p => Console.WriteLine("\t{0}", p.Name));     // Each pod in group
            });

            // --------------------------------------
            // continue at Grouping and projection under Linq queries on pluralsight.
            // --------------------------------------

            
            return;
        }
           
        public void LinkQueryXML()
        {
            // Create an xml document of pods
            var podDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("These be pods"),
                new XElement("Pods",
                    from p in Podlist
                    orderby p.Name
                    select new XElement("Pod",
                        new XAttribute("Name", p.Name),
                        new XElement("ID", p.Id),
                        new XElement("Price", p.StartDate),
                        new XElement("StartDate", p.StartDate),
                        new XElement("Values",                          // Insert from the the list of values in pod
                            from v in p.Values
                            select new XElement("Value", v))
                        
                    )              
            ));

            podDoc.Save(@"C:\_A\PodList.xml");
            
            var xPodDoc = XDocument.Load(@"C:\_A\PodList.xml");

            var PodNamesThatBeginWithE = (from p in xPodDoc.Descendants("Pod")
                                          where p.Attribute("Name").Value.StartsWith("E")     // Access the Name attribute
                                          select p.Attribute("Name").Value
                                         ).ToList(); 
            
            Console.WriteLine("Pod Names from xml file that begin with E");
            PodNamesThatBeginWithE.ForEach(pc => Console.WriteLine("Pod Name: {0}", pc));     
            
            Console.ReadLine();   
        }

        private void GeneratePodlist()
        {
            var podNames = new List<string>()
            {
                "Mercury3", "AtomX", "Baskar", "Triton", "Alamo", "Caltrax", "Heron", "Rover", "Rifter3", "Rifter4", "Rifter5", "Rever", "Locus",
                "Boxcar", "Halvar", "Tilde", "Mavid", "Mixer", "Crisper", "Cruton", "Dolittle", "Dwarf", "Dayton", "Eagle", "Edge", "Evinrude", "Johnson"
            };

            int keyDispersionSize = 4;
            Guid familyKey = Guid.NewGuid();

            for(int i = 0, keyDispersionCount = 0; i < PodCount; i++, keyDispersionCount++)
            {
                if(keyDispersionCount == keyDispersionSize)
                {
                    familyKey = Guid.NewGuid();
                    keyDispersionCount = 0;
                }

                Podlist.Add(
                    new Pod {
                        Id = i,
                        Name = podNames[i],
                        StartDate = DateTime.Now.AddDays(- new Random().Next(0, 365)),
                        Size = new Random().Next(30, 35),
                        Qty = new Random().Next(10, 120),
                        Price = (decimal)(new Random().NextDouble() * 6),
                        Values = new List<int>(){100, 200, 33, 44, 55, 66, 88},
                        FamilyKey = familyKey
                    }
                );

                PodInfolist.Add(new PodInfoItem 
                { 
                    Id = i,
                    PodId = Podlist[i].Id,
                    ManufactoringDate = DateTime.Now                    
                });                
            }
        }
    }
}

/***************************************************************************************
Extension methods are a feature who's main purpose is to be used with LINQ, although they can also be useful in hundreds of different scenarios.
Extension methods are special methods that can extend the data type they are applied to. The most important thing is that you can 
extend existing types even if you do not have the source code and without the need to rebuild class libraries. You can extend .NET built-in types.

.NET built-in extension methods accomplish three main objectives: converting types into other types, data filtering and parsing. The most common 
built-in .NET extension methods are provided by the System.Linq.Enumerable class.

Aggregate – performs an operation on each element of the list taking into account the operations that have gone before. That is to say it performs 
the action on the first and second element and carries the result forward. Then it operates on the previous result and the third element and carries 
forward. etc. You can also start with a seed value by using one of the overloads. The first element is applied first to the seed value.

Example 1. Summing numbers

var nums = new[]{1,2,3,4};
var sum = nums.Aggregate( (a,b) => a + b);
Console.WriteLine(sum); // output: 10 (1+2+3+4)

All – Checks if all elements within a sequence satisfy a condition

Any – Checks if any elements within a sequence satisfy a condition

AsEnumerable – Converts a sequence of elements into an IEnumerable(Of T).

Average – Retrieves the result of the average calculation from the members of a sequence.

Cast – Performs the conversion from an IEnnumerable(Of T)into the specified type. It is generally used explicitly when the compiler cannot infer the appropriate type.

Concat – Returns the concatenation of two sequences.

Contains – Checks if a sequence contains the specified item.

Count – Returns the number of items in a sequence.

DefaultIfEmpty – Returns the elements of the specified sequence or the type parameters default value in a singleton collection if the sequence is empty.
 * Distinct – Ensures that no duplicates are retrieved from a sequence or removes duplicates from the sequence.
 * ElementAt – Obtains the object in the sequence at the specified index.
 * ElementAtOrDefault – Like ElementAt but returns a default value if the index is wrong.
 * Except – Given to sequences, creates a new sequence with elements from the first sequence that are not also in the second one.
 * First - Gets the first element of a sequence.
 * FirstOrDefault - Like first but returns a default value if the first element is not what you are searching for.
 * GroupBy - Given a criteria, groups elements of a sequence into another sequence.
 * GroupJoin - Given a criteria, joins elements from two sequences into one sequence.
 * Intersect - Creates a sequence with common elements from two sequences.
 * Join - Join elements from two sequences based on specific criteria, such as equality.
 * Last - Retrieves the last item in a sequence.
 * Last Or Default - Like last but returns a default value if the specified instance is not found.
 * Long Count - Returns the number of items in a sequence under the form of long type.
 * Max - Retrieves the highest value in a sequence.
 * Min - Retrieves the minimum value in a sequence.
 * Of Type - Folders an IEnumerable collection according to the specified type.
 * Order By - Orders elements in a sequence using the specified criteria.
 * Order By Descending - Orders elements in a sequence using the specified criteria in a descending order.
 * Reverse - Reverses the order of items in a sequence.
 * Select - Puts an item into a sequence for Aquarius.
 * Select Many - puts more than one item into a sequence for queries.
 * Sequence Equals - Determines whether two sequences are equal by comparing the elements by using the default equality comparer for their type or using a specified comparer.
 * Single - Returns the only item from a sequence that matches the specified criteria.
 * SingleOrDefault - Like single but returns a default value if the specified item could not be found.
 * Skip - When creating a new sequence, skips the specified number of items and returns the remaining items from the starting sequence.
 * Skip While - Like Skip but only while the specified condition is satisfied.
 * Sum - In a sequence of numeric values, returns the sum of numbers.
 * Take - Returns the specified number of items starting from the beginning of a sequence.
 * Take While - Like take but only while the specified condition is satisfied.
 * Then By - After invoking OrderBy, provides the ability of a subsequent ordering operation.
 * Then By Descending - After invoking order by, provides the ability of a subsequence ordering operation in a descending way.
 * To Array - Converts an IEnumerable(Of T) into an array.
 * To Dictionary - Converts an IEnumerable(Of T) into a Dictionary(Of T, T).
 * To List - Converts an IEnumerable(Of T) into a List(Of T).
 * To Lookup - Converts an IEnumerable(Of T) into a Lookup(Of TSource, TKey).
 * Union - Creates a new sequence with unique elements from two sequences.
 * Where - Filters a sequence according to the specified criteria.
 * ***************************************************************************************/






















