using TemplaterLibrary;

if (args.Length != 3)
{
    Console.WriteLine("Invalid command line arguments.\n" +
    "Please provide the 3 mandatory arguments:\n" +
    "[templateFilePath] [dataFilePath] [outputFilePath]");
    return;
}

if (!(File.Exists(args[0]) && File.Exists(args[1])))
{
    Console.WriteLine("Invalid command line arguments.\n" +
    "Please check if template and data files " +
    "present in the specified locations");
    return;
}

string template;
string jsonData;
try
{
    template = File.ReadAllText(args[0]);
    jsonData = File.ReadAllText(args[1]);
}
catch (IOException)
{
    Console.WriteLine("There was an error reading a file.");
    return;
}

if (string.IsNullOrWhiteSpace(template) || string.IsNullOrWhiteSpace(jsonData))
{
    Console.WriteLine("Files provided are not valid.");
    return;
}

Templater templater = new();
string result;
try
{
    result = templater.CreateHtml(template, jsonData);
}
catch (Newtonsoft.Json.JsonReaderException)
{
    Console.WriteLine("Failed to retrieve data from JSON file.");
    return;
}

try
{
    File.WriteAllText(args[2], result);
}
catch (IOException)
{
    Console.WriteLine("There was an error writing results to a file.");
    return;
}

Console.WriteLine(result);