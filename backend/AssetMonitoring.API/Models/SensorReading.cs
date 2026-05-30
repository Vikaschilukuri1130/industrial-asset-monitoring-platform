using System.ComponentModel.DataAnnotations;

namespace AssetMonitoring.API.Models
{
    public class SensorReading
    {
        [Key]
        public int SensorReadingId { get; set; }

        public int AssetId { get; set; }

        public double Temperature { get; set; }

        public double Pressure { get; set; }

        public double Vibration { get; set; }

        public double RuntimeHours { get; set; }

        public DateTime ReadingTime { get; set; }
    }
}