using Microsoft.AspNetCore.Mvc;

namespace AssetManagment.Web.Entry.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
