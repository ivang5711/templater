using HtmlAgilityPack;
using TemplaterLibrary;

var doc = new HtmlDocument();
doc.Load(args[1]);
string jsonData = doc.Text;
var template = File.ReadAllText(args[0]);
Templater templater = new();
string result = templater.CreateHtml(template, jsonData);
Console.WriteLine(result);
File.WriteAllText(args[2], result);
