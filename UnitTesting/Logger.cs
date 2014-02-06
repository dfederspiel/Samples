using System;
using Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class Logger
    {
        [TestMethod]
        public void TestLogger()
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

            string crazyString = "Hello, I'm a moderately crazy string";
            currentLogger(crazyString.ToCrazyString());

            currentLogger = Console.Out.WriteLine;
            currentLogger(k.ToString());
        }
    }
}
