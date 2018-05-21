using System.Web.Mvc;



namespace EmailLog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}