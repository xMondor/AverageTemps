using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCreator
{
    public class jsonWriter
    {
        public void WriteDataToJson(string filePath, string output)
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.Write(output);   
            }
        }
    }
}
