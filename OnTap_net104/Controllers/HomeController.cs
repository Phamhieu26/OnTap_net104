using Microsoft.AspNetCore.Mvc;
using OnTap_net104.Models;
using System.Diagnostics;

namespace OnTap_net104.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var sessiondata = HttpContext.Session.GetString("username");
            if (sessiondata == null )
            {
                ViewData["login"] = "Chưa đăng nhập";
            }else ViewData["login"] = "Xin chào"+ sessiondata;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
