using Fluid;
using HtmlAgilityPack;
using Newtonsoft.Json;

// From File
var doc = new HtmlDocument();
doc.Load(@"C:\Users\Smith\source\repos\ivang5711\templater\data.json");

var parser = new FluidParser();

var source = File.ReadAllText(@"C:\Users\Smith\source\repos\ivang5711\templater\template.html");

parser.TryParse(source, out var template);

var res = JsonConvert.DeserializeObject<FromJson>(doc.Text);
var context = new TemplateContext(new Product());
TemplateOptions.Default.Trimming = TrimmingFlags.TagLeft;
context.SetValue("products", res.products);
var result = template.Render(context);
Console.WriteLine(result);

internal class FromJson
{
    public List<Product> products = [];
}

internal class Product
{
    public string name = string.Empty;

    public long price;

    public string description = string.Empty;
}