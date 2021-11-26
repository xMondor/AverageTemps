using DataCreator;

var Test = new GenerateData();
var output = Test.JsonGenerator();
string fileName = "data.json";
string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
var writeToJson = new jsonWriter();
writeToJson.WriteDataToJson(filePath,output);