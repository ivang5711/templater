using TemplaterLibrary;

string message = args.Length != 3 ? 
    "Invalid command line arguments.\n" +
    "Please provide the 3 mandatory arguments:\n" +
    "[templateFilePath] [dataFilePath] [outputFilePath]" : 
    string.Empty;
if (message.Length > 0)
{
    Console.WriteLine(message);
    return;
}

string jsonData = File.ReadAllText(args[1]);
string template = File.ReadAllText(args[0]);
Templater templater = new();
string result = templater.CreateHtml(template, jsonData);
File.WriteAllText(args[2], result);
Console.WriteLine(result);