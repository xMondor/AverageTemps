using AverageTempsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTempsApp.Infrastructure
{
    public class ConfigReader
    {
        public string getCurrentTime(string filePath) {
            var currentTime = new ConfigModel();
            using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    currentTime = JsonConvert.DeserializeObject<ConfigModel>(json);
                }
            return currentTime.Time.ToString();
        }
    }
}
