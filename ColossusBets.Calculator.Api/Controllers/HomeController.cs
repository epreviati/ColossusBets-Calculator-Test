using System.Web.Mvc;

namespace ColossusBets.Calculator.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Colossus Bets Test";

            return View();
        }
    }
}