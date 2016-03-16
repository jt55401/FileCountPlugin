using NewRelic.Platform.Sdk;
using System;

namespace FileCountPlugin
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                Runner runner = new Runner();

                runner.Add(new FileCountAgentFactory());

                runner.SetupAndRun();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred, unable to continue.\n", e.Message);
                return -1;
            }

            return 0;
        }
    }

}
