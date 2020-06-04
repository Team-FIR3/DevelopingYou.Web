using DevelopingYou.Web.Models;
using DevelopingYou.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActiveGoal activeGoal;

        public HomeController(ILogger<HomeController> logger, IActiveGoal activeGoal)
        {
            _logger = logger;
            this.activeGoal = activeGoal;
        }
   

        public async Task<ActionResult<Goal>> Index()
        {
            _logger.LogInformation("We showed home!");
            var activeGoals = await activeGoal.GetActiveGoals();
            return View(activeGoals);

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
