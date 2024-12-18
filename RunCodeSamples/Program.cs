using System;
using System.Collections.Generic;
using DevelopmentInfo.CodeSamples;

namespace DevelopmentInfo.RunCodeSamples
{
    class RunCodeSamples
    {
        static void Main(string[] args)
        {
            int selection = 0;
            bool keepRunning = true;
                        
            while(keepRunning)
            {             
                Console.WriteLine("\nEnter a code selection. Enter 22 to exit.");
                string inputSelection = Console.ReadLine();

                if(!int.TryParse(inputSelection, out selection))
                { 
                    Console.WriteLine("Must input a number and greater than one");
                    continue;
                }                
                
                Console.WriteLine($"Main selection is: {selection}");

                switch (selection)
                {
                    case 1:                        
                        new Collections().EnumerableExtensions();
                        new Collections().ListsInAction();
                        new Collections().ArraysInAction();
                        new Collections().DictionaryGeneric();
                        new Collections().LinkedListClass();
                        new Collections().LinqMultipleFromClausesExamined();
                        new Collections().LinqQueries();
                        new Collections().NameValueCollectionClass();
                        new Collections().VariousCollections();
                    break;
                    case 2:
                        var cSharpCode = new CSharpCode();
                        cSharpCode.CSharpCoding();
                        cSharpCode.ParamPassingTest();
                    break;
                    case 3:
                        var conversions = new Conversions();
                        conversions.FloatToBytesAndBack();
                        conversions.IntToBytesAndBack();
                        conversions.StringToBytesAndBack();
                    break;
                    case 4:
                        new FileOperations().WriteValuesToFile();
                    break;
                    case 5:
                        var databaseOperations = new DatabaseOperations();
                        databaseOperations.SelectEmployeeStoredProcedureNorthwind();
                        databaseOperations.GetCustomerOrdersByNamesNorthwind(new string[] { "Chop-suey Chinese", "Ernst Handel", "Around the horn" });
                    break;
                    case 6:
                        new Internationalization().TwoRegionDemo();
                    break;
                    case 7: // Theads and  tasks
                        new Threading().RunTPLExercises();
                        new Threading().RunThreadExercises();
                    break;
                    case 8:
                       new LINQPractice().RunLinkQuerys();
                       new LINQPractice().LinkQueryXML();
                    break;
                    case 9:
                        new DesignPatterns().RunPatterns();
                    break;
                    case 10:
                        new OopOperations().ExerciseDerivedObjects();
                    break;
                    case 11:
                        new ServiceCalls().RunServiceCalls();
                    break;
                    case 12:
                        new TryThis().GenerateListOfTimes();
                        new TryThis().GenerateListOfThelast120Years();
                        break;
                    case 13:
                        new TryThis().GenerateFibonacciSeries();
                        break;
                    case 14:
                        var attempt = new TryThis();
                        string phrase = "How can mirrors be real if our eyes aren't real";
                        string result = attempt.CapitalizeFirstLetterOfEveryWord(phrase);
                        bool isSquare = attempt.IsSquare(-23);   // 25 = true  5*5
                        List<string> catagories = attempt.OpenOrSenior2(new[] {new[] { 18,20}, new[] { 45,2}, new[] {61,12}, new[] {37,6}, new[] { 21,21}, new[] {78,9} }) as List<string>;
                        string result2 = attempt.ToWeirdCase2("Weird string case");
                        int consonantCount = attempt.ConsonantCount("BbbCaeudXZ&*@3");
                        string result22 = attempt.ReverseWords("battle no requires which that is victory greatest The");
                        string result3 = attempt.ReverseWords2("battle no requires which that is victory greatest The");
                        result = attempt.ReverseLetters("chowDog98Down");
                        bool[] sheeps = new bool[] {true, true, true, false,
                          true, true, true, true,
                          true, false, true, false,
                          true, false, false, true,
                          true, true, true, true,
                          false, false, true, true};

                        int sheepInPlace = attempt.CountSheeps(sheeps);
                        string res4 = TryThis.Greet(); // Calling static method from what could be an instance class.
                        int res5 = TryThis.DescendingOrder(42145);
                        int res6 = attempt.GetSum(3, -2);
                        bool isValidPin = attempt.ValidatePin("1234");
                        int res7 = attempt.MsSinceMidnight(1, 1, 1);
                        int res8 = attempt.MsSinceMidnight(29, 1, 1);
                        int res9 = attempt.MsSinceMidnight(2, 88, 1);
                        int res10 = attempt.MsSinceMidnight(2, 2, 88);

                        var oddOrEvenVals = new int[] {100,88,-1};
                        string res11 = attempt.OddOrEvenSum(oddOrEvenVals);
                        //string rw = attempt.ReplaceWords("This is an example!");
                        string rw = attempt.ReplaceWords("Dog Bird Cat Fish!");
                        // Return the number of people still on the bus.
                        List<int[]> peopleList = new List<int[]>() { new int[] {10,0},new int[] {3,5},new int[] {5,8} };
                        int res12 = (TryThis.NumberOfPeopleOnBus(peopleList) > 0) ? TryThis.NumberOfPeopleOnBus(peopleList) : 0; 
                        string res13 = attempt.Smash(new string[] {"hello", "world", "this", "is", "great" });
                        int res14 = attempt.GetVowelCount("xbracxdabrau");

                        int resValue = attempt.TestThis();

                        break;
                    case 15:
                        var newItems = new string[] { "itemB", "itemA", "itemC", "itemE", "itemD" };
                        var oldItems = new string[] { "itemA", "itemB", "itemC", "itemD", "itemE", "itemF" };
                        string[] itemsAdded = new TryThis().GetItemsNotInOriginalList(newItems, oldItems);
                        break;
                    case 22:
                        // Environment.Exit(0);
                        keepRunning = false;
                    break;
                    default:
                        Console.WriteLine("Invalid Selection");
                    break;
                }
            }
        }
    }
}

