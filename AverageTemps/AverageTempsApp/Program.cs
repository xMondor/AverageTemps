using AverageTempsApp.Handlers;
using AverageTempsApp.Infrastructure;
using AverageTempsApp.Models;
using CommandLine;
using System.Globalization;

Parser.Default.ParseArguments<ArgumentHandler>(args)
               .WithParsed(RunOptions);
static void RunOptions(ArgumentHandler opts)
{
    var validation = new ArgumentValidator();
    bool valid = validation.Validate(opts);
    if (valid)
    {
        var app = new Application();
        app.Run(opts);
   }

}
public class Application
{
    public void Run(ArgumentHandler opts)
    {
        string dateTime;

        var list = new jsonReader();
        var config = new ConfigReader();
        var report = new ReportGenerator();
        var print = new Print();

        if (opts.CurrentTime.Equals("config"))
        {
            dateTime = config.getCurrentTime(opts.configFile);
        }
        else
        {
            dateTime = opts.CurrentTime;
        }
        var timeSpans = list.ReadJsonFile(opts.dataFile);
        var average = report.GenerateReport(timeSpans, dateTime);
        print.PrintCurrentTime(dateTime);
        print.PrintAverageReport(average);
    }
}


