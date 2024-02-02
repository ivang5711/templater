using Fluid;
using Newtonsoft.Json;
using TemplaterLibrary.Models;

namespace TemplaterLibrary
{
    public class Templater
    {
        private IFluidTemplate _templateParsed;

        private JsonData _data;

        private TemplateContext _context;

        public string CreateHtml(string template, string jsonData)
        {
            ParseTemplate(template);
            GetData(jsonData);
            SetTemplateContext();
            return _templateParsed.Render(_context);
        }

        private void SetTemplateContext()
        {
            _context = new TemplateContext(new Product());
            TemplateOptions.Default.Trimming = TrimmingFlags.TagLeft;
            _context.SetValue("products", _data.products);
        }

        private void GetData(string jsonData)
        {
            _data = JsonConvert.DeserializeObject<JsonData>(jsonData);
        }

        private void ParseTemplate(string template)
        {
            FluidParser parser = new FluidParser();
            parser.TryParse(template, out _templateParsed);
        }
    }
}