using BioGenom.API.Contracts;
using BioGenom.API.Mappers;
using BioGenom.DB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BioGenom.API.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly IProductRepository _productRepository;

        public ReportsController(IReportRepository reportRepository, IProductRepository productRepository)
        {
            _reportRepository = reportRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ReportResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var report = await _reportRepository.GetLatestReportAsync();
            if (report == null)
                return NotFound("Отчёт не найден");

            var response = ReportMapper.ToResponse(report);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save([FromBody] ReportRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var invalidItems = new List<string>(); //TODO: перенести в сервис

            if (request.PersonalizedSet?.Items.Count > 0)
            {
                var validationTasks = request.PersonalizedSet.Items.Select(async item =>
                {
                    var exists = await _productRepository.ExistsAsync(item.ProductId);
                    if (!exists)
                        return $"ProductId {item.ProductId} не найден в базе";

                    return null;
                });

                var results = await Task.WhenAll(validationTasks);
                invalidItems.AddRange(results.Where(msg => msg != null)!);
            }

            if (invalidItems.Count > 0)
            {
                return BadRequest(invalidItems);
            }

            var report = ReportMapper.ToEntity(request);
            await _reportRepository.SaveReportAsync(report);

            return Ok();
        }
    }
}