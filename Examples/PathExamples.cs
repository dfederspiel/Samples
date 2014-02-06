using System;
using System.IO;
using System.Linq;

namespace Examples
{
    public class PathExamples
    {
        public static Log logger = Console.Out.WriteLine;

        public PathExamples()
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
