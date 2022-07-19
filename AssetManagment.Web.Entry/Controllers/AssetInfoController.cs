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
            ViewBag.Description = "数据维护";
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public IActionResult Category()
        {
            ViewBag.Description = "资产类别";
            return View();
        }

        public IActionResult Department()
        {
            ViewBag.Description = "部门管理";
            return View();
        }

        public IActionResult Region()
        {
            ViewBag.Description = "地区管理";
            return View();
        }

        public IActionResult Storage()
        {
            ViewBag.Description = "存储地方管理";
            return View();
        }

        public IActionResult AssetStatus()
        {
            ViewBag.Description = "资产状态";
            return View();
        }

        public IActionResult AssetSource()
        {
            ViewBag.Description = "资产来源";
            return View();
        }
    }
}
