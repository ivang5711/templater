using Fluid;
using Newtonsoft.Json;
using TemplaterLibrary.Models;

namespace TemplaterLibrary
{
    public class Templater
    {
        public string CreateHtml(string template, string jsonData)
        {
            var parser = new FluidParser();
            parser.TryParse(template, out var templateParsed);
            var res = JsonConvert.DeserializeObject<JsonData>(jsonData);
            var context = new TemplateContext(new Product());
            TemplateOptions.Default.Trimming = TrimmingFlags.TagLeft;
            context.SetValue("products", res.products);
            var result = templateParsed.Render(context);
            return result;
        }
    }
}