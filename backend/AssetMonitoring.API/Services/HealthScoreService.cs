namespace AssetMonitoring.API.Services
{
    public class HealthScoreService
    {
        public int CalculateHealthScore(
            double temperature,
            double pressure,
            double vibration)
        {
            int score = 100;

            if (temperature > 90)
                score -= 25;

            if (pressure > 150)
                score -= 20;

            if (vibration > 70)
                score -= 25;

            return Math.Max(score, 0);
        }
    }
}