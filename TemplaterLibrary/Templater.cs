using Fluid;
using Newtonsoft.Json;
using TemplaterLibrary.Models;

namespace TemplaterLibrary
{
    public class Templater
    {
        private const string templateValueName = "products";

        private IFluidTemplate _templateParsed;

        private JsonData _data;

        private TemplateContext _context;

        /// <summary>
        /// Generates HTML based on the provided template and data
        /// </summary>
        /// <param name="template"></param>
        /// <param name="jsonData"></param>
        /// <returns>returns HTML as a single string</returns>
        public string CreateHtml(string template, string jsonData)
        {
            if (!ParseTemplate(template))
            {
                return string.Empty;
            }

            GetData(jsonData);
            SetUpTemplate();
            return _templateParsed.Render(_context);
        }

        private void SetUpTemplate()
        {
            SetTemplateOptions();
            SetTemplateContext();
        }

        private void SetTemplateContext()
        {
            _context = new TemplateContext(new Product());
            _context.SetValue(templateValueName, _data.products);
        }

        private static void SetTemplateOptions()
        {
            TemplateOptions.Default.Trimming = TrimmingFlags.TagLeft;
        }

        private void GetData(string jsonData)
        {
            _data = JsonConvert.DeserializeObject<JsonData>(jsonData);
        }

        private bool ParseTemplate(string template)
        {
            FluidParser parser = new FluidParser();
            return parser.TryParse(template, out _templateParsed);
        }
    }
}