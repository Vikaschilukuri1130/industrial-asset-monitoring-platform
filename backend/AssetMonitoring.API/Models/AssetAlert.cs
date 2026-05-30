using System.ComponentModel.DataAnnotations;

namespace AssetMonitoring.API.Models
{
    public class AssetAlert
    {
        [Key]
        public int AlertId { get; set; }

        public int AssetId { get; set; }

        public string AlertType { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public string Severity { get; set; } = string.Empty;
    }
}