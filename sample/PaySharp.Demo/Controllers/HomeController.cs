using PaySharp.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PaySharp.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
