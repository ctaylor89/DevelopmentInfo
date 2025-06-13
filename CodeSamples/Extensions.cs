using System;
using System.Collections.Generic;

namespace DevelopmentInfo.CodeSamples
{
    // Extension class has to be static
    public static class Extensions
    {
        // Extension method has to be static
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");  // See Note A
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Double the integer value
        /// </summary>
        public static int DoubleIt(this int source)
        {
            return source * 2;
        }
    }
}

// Note A: Never throw NullReferenceException, as this is a framework run-time exception and should never be thrown explicitly.
//
// While it's possible to write extension methods on nearly any type, it doesn't really make sense to do this if you can modify
// the class safely and directly.