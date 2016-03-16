using System;
using System.Text;
using NewRelic.Platform.Sdk;
using NewRelic.Platform.Sdk.Processors;
using NewRelic.Platform.Sdk.Utils;
using System.IO;

namespace FileCountPlugin
{

    class FileCountAgent : Agent
    {
        private static Logger s_log = Logger.GetLogger("FileCountAgent");

        public override string Guid { get { return "com.jason-grey.filecount"; } }
        public override string Version { get { return "1.0.0"; } }


        public string Name;
        public string Directory;

        public FileCountAgent(string name, string directory)
        {
            this.Name = name;
            this.Directory = directory;

            s_log.Info("Created an agent for ", name, directory);

        }

        public override string GetAgentName()
        {
            return this.Name;
        }

        public override void PollCycle()
        {
            s_log.Debug("polled");

            string[] filePaths = System.IO.Directory.GetFiles(this.Directory);

            int numFiles = filePaths.Length;

            ReportMetric("File/Count", "files", numFiles);
        }

    }
}
