using Microsoft.AspNetCore.Mvc;

namespace MyChinook_Web.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
