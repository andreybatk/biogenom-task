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

        public ReportsController(IReportRepository repository)
        {
            _reportRepository = repository;
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

            var report = ReportMapper.ToEntity(request);
            await _reportRepository.SaveReportAsync(report);

            return Ok();
        }
    }
}