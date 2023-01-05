using System;
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
                       new LINQPractice().RunQuerys();
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
