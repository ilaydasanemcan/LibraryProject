using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.UI.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
