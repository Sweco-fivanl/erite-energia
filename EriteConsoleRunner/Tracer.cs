using System;
using System.Diagnostics;

namespace EriteConsoleRunner
{
    public class Tracer
    {
        public static void _trace(string what)
        {
            Trace.WriteLine(GetMessage(what));
        }

        public static void _debug(string what)
        {
            Debug.WriteLine(GetMessage(what));
        }

        private static string GetMessage(string what)
        {
            var pp = "";
            try
            {
                pp = AppDomain.CurrentDomain.FriendlyName;
            }
            catch
            {
                // ignored
            }
            return string.Format("[BIMDEVEL] {0}: {1}", pp, what);
        }
    }
}