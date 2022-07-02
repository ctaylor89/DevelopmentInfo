using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PracticeConsole
{
   public class Samples
   {
      public void TestConditionalMethodCall()
      {
         Console.WriteLine("Calling conditional method");
         TestConditionalMethodCalled();
         Console.WriteLine("Called conditional method");
      }

      // This method will only be called if this project is built as a debug build
      [Conditional("DEBUG")]
      private void TestConditionalMethodCalled()
      {
         Console.WriteLine("Conditional method executed");
      }
   }
}
