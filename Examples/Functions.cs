using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Examples
{
    class Functions
    {
        static readonly string[] theList = { ".notgood", ".ohcrap", ".cantget" };
        static readonly string[] theFiles = { "myfile.notgood", "yourfile.ohcrap", "herfile.goodtimes", "hisfile.cantget" };

        static Func<string, bool> IsValid
        {
            get
            {
                return u => !theList.Contains(Path.GetExtension(u));
            }
        }
        static IEnumerable<string> GetValidStrings()
        {
            return theFiles.Where(IsValid);
        }
    }
}
