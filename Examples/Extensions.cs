using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    public static class Extensions
    {
        public static String ToCrazyString(this String s)
        {
            return s + " CRAZY!!!";
            // Comment
        }

        public static IEnumerable<string> ToProcessedStrings(this IEnumerable<string> strings)
        {
            foreach (var name in strings)
                yield return string.Format("FORMATTED:{0}", name);
        }
    }
}
