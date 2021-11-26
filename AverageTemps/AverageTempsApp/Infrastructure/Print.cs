using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTempsApp.Infrastructure
{
    public class Print
    {
        public void PrintAverageReport(string average)
            {
            var str = new StringBuilder();
            str.Append("The average temperature was: ");
            str.Append(average);    
            Console.WriteLine(str); 
        }
        public void PrintCurrentTime(string currentTime)
        {
            var str = new StringBuilder();
            str.Append("The current time is: ");
            str.Append(currentTime);
            Console.WriteLine(str);
        }
    }
}
