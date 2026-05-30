using AssetMonitoring.API.Models;

namespace AssetMonitoring.API.Services
{
    public class AlertService
    {
        public AssetAlert? GenerateAlert(
            int assetId,
            double temperature,
            double pressure,
            double vibration)
        {
            if (temperature > 90)
            {
                return new AssetAlert
                {
                    AssetId = assetId,
                    AlertType = "Temperature",
                    Message = "Critical temperature threshold exceeded.",
                    Severity = "High",
                    CreatedDate = DateTime.UtcNow
                };
            }

            if (pressure > 150)
            {
                return new AssetAlert
                {
                    AssetId = assetId,
                    AlertType = "Pressure",
                    Message = "Pressure threshold exceeded.",
                    Severity = "Medium",
                    CreatedDate = DateTime.UtcNow
                };
            }

            if (vibration > 70)
            {
                return new AssetAlert
                {
                    AssetId = assetId,
                    AlertType = "Vibration",
                    Message = "Abnormal vibration detected.",
                    Severity = "High",
                    CreatedDate = DateTime.UtcNow
                };
            }

            return null;
        }
    }
}