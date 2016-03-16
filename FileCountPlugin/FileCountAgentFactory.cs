using NewRelic.Platform.Sdk;
using System;
using System.Collections.Generic;

namespace FileCountPlugin
{
    class FileCountAgentFactory : AgentFactory
    {
        public override Agent CreateAgentWithConfiguration(IDictionary<string, object> properties)
        {

            string name = (string)properties["name"];
            string directory = (string)properties["directory"];

            return new FileCountAgent(name, directory);

        }
    }
}
