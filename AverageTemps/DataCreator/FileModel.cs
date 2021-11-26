using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCreator
{
    public class FileModel
    {
        public string Time { get; set; }
        public string Temperature { get; set; }

        public FileModel(string v1, string v2)
        {
            this.Time = v1;
            this.Temperature = v2;
        }


    }
}
