using System.Web.Mvc;

namespace IntroductoryProject3._1.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
