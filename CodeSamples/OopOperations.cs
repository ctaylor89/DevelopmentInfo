using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DevelopmentInfo.Entities;

namespace DevelopmentInfo.CodeSamples
{
    public class OopOperations
    {
        public void ExerciseDerivedObjects()
        {
            Console.WriteLine($"Starting method: {MethodBase.GetCurrentMethod().Name}()");

            SendMessages.WriteConsoleMessageStatic("Static func in regular class. Cannot access through an instance");

            Messages msgs = new SendMessages();
            msgs.WriteMessage("Writing msg using abstract class");
            
            // msgs.WriteConsoleMessageStatic("...");  // Cannot call a static func through a class instance

            var sendMsgs = new SendMessages();
            sendMsgs.WriteMessage("Calling implementation of abstract method");
            sendMsgs.WriteConsoleMessage("Calling the override method in the derived class");
            
            var bc = new BaseClass();
            var dc = new DerivedClass();
            BaseClass bcdc = new DerivedClass();    // Slicing occurs if assign an object of a derived class to an instance of a base class
            BaseClass bcdc2 = new DerivedClass2();

            Console.WriteLine("Calling bc.Method1()");
            bc.Method1();
            Console.WriteLine("Calling dc.Method1()");
            dc.Method1();
            Console.WriteLine("Calling dc.Method2()");
            dc.Method2();
            Console.WriteLine("Calling bcdc.Method1()");
            bcdc.Method1();     // Will call method1 in derived class because it is overridden
            Console.WriteLine("Calling bcdc.Method2()");
            bcdc.Method2();     // Will call method2 in base class because it is not overridden
            Console.WriteLine("Calling dc.Method3()");
            dc.Method3();       // Will call method3 in derived class because it is overridden
                                // and will also call the base class method throught base.Method3()

            dc.Name = "";       // Assign a value to a property override
            dc.Name = "Bart";
            dc.Name = null;

            Console.WriteLine("Call methods in DerivedClass2 from BaseClass Instance");
            bcdc2.Method1();
            bcdc2.Method2();
            bcdc2.Method3();

             // bc.staticValue = 500;            // Not assesible through instance
            BaseClass.staticValue = 500;        // Assesible only through type

            Mystatic.Y = 777;
            Mystatic.WriteValue();

            // var m = new Mystatic(); // Cannot create an instance of a static class

        }
    }
}
