using AverageTempsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTempsApp.Infrastructure
{
    public class jsonReader
    {
        public List<FileModel> ReadJsonFile(string fileInput)
        {
            var timeSpans = new List<FileModel>();
            using (StreamReader reader = new StreamReader(fileInput))
            {
                string json = reader.ReadToEnd();
                timeSpans = JsonConvert.DeserializeObject<List<FileModel>>(json);
            }
            return timeSpans;
        }
    }
}
