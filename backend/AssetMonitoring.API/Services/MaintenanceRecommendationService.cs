namespace AssetMonitoring.API.Services
{
    public class MaintenanceRecommendationService
    {
        public string GetRecommendation(
            double temperature,
            double pressure,
            double vibration,
            double runtimeHours)
        {
            if (temperature > 90)
                return "Immediate maintenance required due to high temperature.";

            if (pressure > 150)
                return "Inspect pressure system within 24 hours.";

            if (vibration > 70)
                return "Check mechanical components for abnormal vibration.";

            if (runtimeHours > 5000)
                return "Schedule preventive maintenance based on runtime hours.";

            return "Asset operating normally.";
        }
    }
}