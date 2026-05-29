using AssetMonitoring.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetMonitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private static readonly List<Asset> Assets = new()
        {
            new Asset
            {
                AssetId = 1,
                AssetName = "Compressor Unit A1",
                AssetType = "Compressor",
                Location = "Plant 1",
                Status = "Operational",
                InstalledDate = new DateTime(2023, 1, 15),
                LastMaintenanceDate = new DateTime(2025, 12, 10)
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Asset>> GetAssets()
        {
            return Ok(Assets);
        }

        [HttpGet("{id}")]
        public ActionResult<Asset> GetAssetById(int id)
        {
            var asset = Assets.FirstOrDefault(a => a.AssetId == id);

            if (asset == null)
                return NotFound();

            return Ok(asset);
        }

        [HttpPost]
        public ActionResult<Asset> CreateAsset(Asset asset)
        {
            asset.AssetId = Assets.Count + 1;
            Assets.Add(asset);

            return CreatedAtAction(nameof(GetAssetById), new { id = asset.AssetId }, asset);
        }
    }
}