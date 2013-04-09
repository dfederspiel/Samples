using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examples;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class Logger
    {
        [TestMethod]
        public void TestMethod1()
        {
            var k = new Kennel();

            Log currentLogger = Console.Out.WriteLine;
            currentLogger("Logging to Console");

            currentLogger = Console.Error.WriteLine;
            currentLogger("Logging Error to Console");

            currentLogger = ConsoleLogger.LogMessage;
            currentLogger("This will fail");

            currentLogger = TextLogger.LogSomeMoreMessagesIDontCareWhatTheMethodNAmeIs;
            currentLogger("Another failure");

            currentLogger = TextLogger.BlahBlahMethodStringSignature;
            currentLogger("Blah Blah Messaging");


            PathSamples pathSamples = new PathSamples();

            Test t = new Test(k);

            List<string> strings = new List<string> { "string1", "string2" };
            var x = strings.ToProcessedStrings();

            string crazyString = "Hello, I'm a moderately crazy string";
            currentLogger(crazyString.ToCrazyString());

            currentLogger = Console.Out.WriteLine;
            currentLogger(k.ToString());
        }
    }
}
