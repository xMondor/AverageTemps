using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTempsApp.Handlers
{
    
    public class ArgumentHandler
    {
        [Option('d', "data", Required =true, HelpText = "Location of the json data file")]
        public string dataFile { get; set; }

        [Option('c', "config", Required =true, HelpText = "Location of the json config file")]
        public string configFile { get; set; }

        [Option('t', "time", Default ="config", HelpText = "Current time in format HH:mm:ss")]
        public string CurrentTime { get; set; }
    }
}
