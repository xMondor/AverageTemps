using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTempsApp.Handlers
{
    public class ArgumentValidator
    {
        public bool Validate(ArgumentHandler opts)
        {
            if (!opts.CurrentTime.Equals("config"))
            {
                if (!CurrentTimeValidator(opts.CurrentTime))
                {
                    return false;
                }
            }
            if (!DataFileValidator(opts.dataFile))
            {
                return false;
            }
            if (!ConfigFileValidator(opts.configFile))
            {
                return false;
            }
            return true;
        }
        public bool CurrentTimeValidator(string currentTime)
        {
            DateTime dateTime;
            if (!DateTime.TryParseExact(currentTime, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                Console.WriteLine("Time is not written in the correct format: HH:mm:ss");
                return false;
            }
            return true;
        }
        public bool DataFileValidator (string filePath)
        {
            if (!filePath.ToLower().EndsWith(".json")){
                Console.WriteLine("Data file is not an json file");
                return false;
            }
            if(!File.Exists(filePath))
            {
                Console.WriteLine("The specified file does not exist");
                return false;
            }
            return true;
        }
        public bool ConfigFileValidator(string filePath)
        {
            if (!filePath.ToLower().EndsWith(".json"))
            {
                Console.WriteLine("Config file is not an json file");
                return false;
            }
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The specified file does not exist");
                return false;
            }
            return true;
        }
    }
}
