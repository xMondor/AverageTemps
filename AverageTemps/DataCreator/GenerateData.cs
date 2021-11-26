using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCreator
{
    public class GenerateData
    {
        public string JsonGenerator() {
            var rand = new Random();
            List<FileModel> modelList = new List<FileModel>();
            string output = String.Empty;
            for (int i = 0; i< 1440; i++)
            {
                double dec = rand.NextDouble();
                int temp = rand.Next(70, 75);
                var finalTemp = Math.Round(temp + dec, 1);
                var model = new FileModel
                    (
                DateTime.MinValue.AddMinutes(i).ToString("HH:mm:ss.fff"),
                finalTemp.ToString()
                );
                modelList.Add(model);
            }
            output = JsonConvert.SerializeObject(modelList);

            return output;
        }
    }
}
