namespace AssetMonitoring.API.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = "Operational";
        public DateTime InstalledDate { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
    }
}