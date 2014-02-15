using System;
using System.IO;
using System.Linq;

namespace Examples
{
    public class PathExamples
    {
        public static Log Logger = Console.Out.WriteLine;

        public PathExamples()
        {
            var fileName = "Resources/photo.jpg";
            Logger(fileName);
            Logger(Path.ChangeExtension(fileName, "png"));
            Logger(Path.GetDirectoryName(fileName));
            Logger(Path.GetFileName(fileName));
            Logger(Path.GetFileNameWithoutExtension(fileName));
            Logger(Path.GetRandomFileName());
        }
    }
}
