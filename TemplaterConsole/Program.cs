using HtmlAgilityPack;
using TemplaterLibrary;

var doc = new HtmlDocument();
doc.Load(@"C:\Users\Smith\source\repos\ivang5711\templater\data.json");
string jsonData = doc.Text;
var template = File.ReadAllText(@"C:\Users\Smith\source\repos\ivang5711\templater\template.html");
Templater templater = new();
string result = templater.CreateHtml(template, jsonData);
Console.WriteLine(result);
