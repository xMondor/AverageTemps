using AverageTempsApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTempsApp.Handlers
{
    public class ReportGenerator
    {
        public string GenerateReport(List<FileModel> _timeSpans, string _currentTime)
        {
            if (_timeSpans is null)
            {
                throw new ArgumentNullException(nameof(_timeSpans));
            }

            if (string.IsNullOrEmpty(_currentTime))
            {
                throw new ArgumentException($"'{nameof(_currentTime)}' cannot be null or empty.", nameof(_currentTime));
            }

            DateTime currentTime;
            double totalTemp = 0;
            int timeIndex = 0;
            DateTime time;
            DateTime.TryParseExact(_currentTime, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out currentTime);
            var startTime = currentTime.AddMinutes(-59);
            if (startTime.Day < currentTime.Day)
            {
                startTime = startTime.AddDays(1);
                startTime = DateTime.Today;
            }
            foreach (var timespan in _timeSpans)
            {
                time = DateTime.Parse(timespan.Time);

                if(TimeBetween(startTime, currentTime, time))
                {
                    double temperature = 0;
                    temperature = double.Parse(timespan.Temperature);

                    timeIndex++;

                    totalTemp += temperature;
                }
            }
            var final = Math.Round(totalTemp / timeIndex, 1);
            return final.ToString();

        }
        private bool TimeBetween(DateTime startTime, DateTime currentTime, DateTime time)
        {
            
            if(startTime<=time && currentTime>=time)
            {
                return true;
            }
            return false;
        }

    }
}
