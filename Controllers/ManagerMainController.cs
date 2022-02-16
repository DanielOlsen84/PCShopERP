using Microsoft.AspNetCore.Mvc;

namespace PCShopERP.Controllers
{
    public class ManagerMainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
