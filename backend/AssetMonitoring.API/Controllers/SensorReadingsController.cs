using AssetMonitoring.API.Data;
using AssetMonitoring.API.Models;
using AssetMonitoring.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetMonitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorReadingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HealthScoreService _healthScoreService = new();
        private readonly AlertService _alertService = new();
        private readonly MaintenanceRecommendationService _recommendationService = new();

        public SensorReadingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorReading>>> GetSensorReadings()
        {
            return await _context.SensorReadings.ToListAsync();
        }

        [HttpGet("alerts")]
        public async Task<ActionResult<IEnumerable<AssetAlert>>> GetAlerts()
        {
            return await _context.AssetAlerts.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateSensorReading(SensorReading reading)
        {
            var assetExists = await _context.Assets.AnyAsync(a => a.AssetId == reading.AssetId);

            if (!assetExists)
                return BadRequest("AssetId does not exist.");

            reading.SensorReadingId = 0;
            reading.ReadingTime = DateTime.UtcNow;

            _context.SensorReadings.Add(reading);

            int healthScore = _healthScoreService.CalculateHealthScore(
                reading.Temperature,
                reading.Pressure,
                reading.Vibration
            );

            var recommendation = _recommendationService.GetRecommendation(
                reading.Temperature,
                reading.Pressure,
                reading.Vibration,
                reading.RuntimeHours
            );

            var alert = _alertService.GenerateAlert(
                reading.AssetId,
                reading.Temperature,
                reading.Pressure,
                reading.Vibration
            );

            if (alert != null)
            {
                alert.AlertId = 0;
                _context.AssetAlerts.Add(alert);
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Sensor reading processed and saved successfully",
                Reading = reading,
                HealthScore = healthScore,
                Recommendation = recommendation,
                AlertGenerated = alert != null,
                Alert = alert
            });
        }
    }
}