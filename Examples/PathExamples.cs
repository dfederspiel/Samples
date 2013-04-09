using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class PathSamples
    {
        public static Log logger = Console.Out.WriteLine;

        public PathSamples()
        {
            var fileName = "Resources/photo.jpg";
            logger(fileName);
            logger(Path.ChangeExtension(fileName, "png"));
            logger(Path.GetDirectoryName(fileName));
            logger(Path.GetFileName(fileName));
            logger(Path.GetFileNameWithoutExtension(fileName));
            logger(Path.GetRandomFileName());
        }
    }
}
