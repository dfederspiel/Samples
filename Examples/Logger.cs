using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public delegate void Log(string message);

    public static class ConsoleLogger
    {
        public static void LogMessage(string message)
        {
            Console.Out.WriteLine("From ConsoleLogger.LogMessage: " + message);
        }
    }

    public static class TextLogger
    {
        public static void LogSomeMoreMessagesIDontCareWhatTheMethodNAmeIs(string message)
        {
            Console.Out.WriteLine("From TextLogger.LogSomeMoreMessagesIDontCareWhatTheMethodNAmeIs: " + message);
        }

        public static void BlahBlahMethodStringSignature(string blahblahmessage)
        {
            Console.Out.WriteLine("From TextLogger.BlahBlahMethodStringSignature: " + blahblahmessage);
        }
    }
}
