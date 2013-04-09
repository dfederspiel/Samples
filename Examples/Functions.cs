using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Functions
    {
        static string[] theList = { ".notgood", ".ohcrap", ".cantget" };
        static string[] theFiles = { "myfile.notgood", "yourfile.ohcrap", "herfile.goodtimes", "hisfile.cantget" };

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
