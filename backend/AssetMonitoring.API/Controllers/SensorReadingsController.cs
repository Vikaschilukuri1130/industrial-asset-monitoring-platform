using AssetMonitoring.API.Models;
using AssetMonitoring.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetMonitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorReadingsController : ControllerBase
    {
        private static readonly List<SensorReading> SensorReadings = new();
        private static readonly List<AssetAlert> Alerts = new();

        private readonly HealthScoreService _healthScoreService = new();
        private readonly AlertService _alertService = new();

        [HttpGet]
        public ActionResult<IEnumerable<SensorReading>> GetSensorReadings()
        {
            return Ok(SensorReadings);
        }

        [HttpGet("alerts")]
        public ActionResult<IEnumerable<AssetAlert>> GetAlerts()
        {
            return Ok(Alerts);
        }

        [HttpPost]
        public ActionResult<object> CreateSensorReading(SensorReading reading)
        {
            reading.SensorReadingId = SensorReadings.Count + 1;
            reading.ReadingTime = DateTime.UtcNow;

            SensorReadings.Add(reading);

            int healthScore = _healthScoreService.CalculateHealthScore(
                reading.Temperature,
                reading.Pressure,
                reading.Vibration
            );

            var alert = _alertService.GenerateAlert(
                reading.AssetId,
                reading.Temperature,
                reading.Pressure,
                reading.Vibration
            );

            if (alert != null)
            {
                alert.AlertId = Alerts.Count + 1;
                Alerts.Add(alert);
            }

            return Ok(new
            {
                Message = "Sensor reading processed successfully",
                Reading = reading,
                HealthScore = healthScore,
                AlertGenerated = alert != null,
                Alert = alert
            });
        }
    }
}