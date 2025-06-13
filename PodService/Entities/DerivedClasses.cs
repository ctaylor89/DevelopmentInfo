using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentInfo.Entities
{
    // Can only be derived from and never instantiated. You can assign an instance of a derived class to a
    // declared member of an abstract class.
    public abstract class Messages
    {
        // Abstract method must be implemented in derived class.
        public abstract void WriteMessage(string msg);

        public virtual void WriteConsoleMessage(string message)
        {
            Console.WriteLine("From abstract class: {0}", message);
        }
    }

    public class SendMessages : Messages
    {
        public override void WriteMessage(string msg)
        {
            Console.WriteLine("From implementation of abstract class: {0}", msg);
        }

        // With out this override the virtual base class method will be called
        public override sealed void WriteConsoleMessage(string message)
        {
            Console.WriteLine("From override method: {0}", message);
        }

        // Cannot access through an instance of this class
        public static void WriteConsoleMessageX(string message)
        {
            Console.WriteLine("Static method test: {0}", message);
        }
    }

    public class BaseClass
    {
        // An abstract method can only exist in an abstract class. If you make this an abstract class,
        // you cannot create an instance of it.
        // public abstract void MethodAbstract();
        
        // Static properties and methods can only be accessed by type and not an instance.
        public static int staticValue {get; set;}

        public virtual void Method1()
        {
            Console.WriteLine("Base - Method1");
        }
        
        public virtual void Method2()
        {
            Console.WriteLine("Base - Method2");
        }

        public virtual void Method3()
        {
            Console.WriteLine("Base - Method3");
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public override sealed void Method1()
        {
            Console.WriteLine("Derived - Method1");
        }

        // The new keyword is for clarity. Simply not using override stops the polymorphism.
        public new void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }
        
        public override void Method3()
        {
            Console.WriteLine("Derived - Method3");
            base.Method3();  // Call the previous parent class
        }
    }

    public class DerivedClass2 : DerivedClass
    {
        public new void Method1()
        {
            Console.WriteLine("Derived 2 - Method1");
        }
        
        public override void Method3()
        {
            Console.WriteLine("Derived 2 - Method3");
            base.Method3();  // Call the previous parent class
        }

        public void Method4()
        {
            Console.WriteLine("Derived 2 - Method4");
        }
    }

    // Static class example. Can only have static members. Cannot be instantiated
    public static class Mystatic
    {
        private static readonly int X;
        public static int Y { get; set; }

        // Can not have a non static field
        // private int y;

        // Access modifier "public" cannot be applied to static constructors
        // A static constructor is called automatically to initialize the class before 
        // the first instance is created or any static members are referenced.
        static Mystatic()
        {
            X = 3000;
            Y = 5000;
        }

        public static void WriteValue()
        {
            Console.WriteLine("Static Method call: X = {0}  Y = {1}", X, Y);
        }
    }
}

// Notes:
//The user has no control on when the static constructor is executed in the program.
//A typical use of static constructors is when the class is using a log file and the constructor is used 
//to write entries to this file.

//Static constructors are also useful when creating wrapper classes for unmanaged code, when the constructor 
//can call the LoadLibrary method.

//If a static constructor throws an exception, the runtime will not invoke it a second time, and the type 
//will remain uninitialized for the lifetime of the application domain in which your program is running.

// An abstract class can be the child of a concrete class. An abstract method declaration is permitted to 
// override a virtual method. This allows an abstract class to force re-implementation of the method in 
// derived classes, and makes the original implementation of the method unavailable
/*
using System;
class A
{
   public virtual void F() {
      Console.WriteLine("A.F");
   }
}
abstract class B: A
{
   public abstract override void F();
}
class C: B
{
   public override void F() {
      Console.WriteLine("C.F");
   }
}
*/
