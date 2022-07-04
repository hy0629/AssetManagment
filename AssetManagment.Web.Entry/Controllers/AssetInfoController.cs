using AssetManagment.Application.Asset;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagment.Web.Entry.Controllers
{
    public class AssetInfoController : Controller
    {
        private readonly IAssetService _assetService;

        public AssetInfoController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        public IActionResult Index([FromQuery] int page = 1)
        {
            ViewBag.AssetList = _assetService.GetAssetInfos(page);
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }
    }
}
