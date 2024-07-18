using Microsoft.AspNetCore.Mvc;

namespace MachineLearningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentClassificationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DocumentClassificationController> _logger;

        public DocumentClassificationController(ILogger<DocumentClassificationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GeDocumentClassification")]
        public IEnumerable<DocumentClassification> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new DocumentClassification
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public class DocumentClassification
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
