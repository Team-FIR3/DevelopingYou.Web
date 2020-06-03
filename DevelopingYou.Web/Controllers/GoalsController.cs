using DevelopingYou.Web.Models;
using DevelopingYou.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Controllers
{
    public class GoalsController : Controller
    {
        private readonly IGoalService goalService;

        public GoalsController(IGoalService goalService)
        {
            this.goalService = goalService;
        }

        public async Task<ActionResult<Goal>> Index()
        {
            var goals = await goalService.GetGoals();

            return View(goals);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var goal = await goalService.GetOneGoal(id);

            return View(goal);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Goal>> Create(Goal goal)
        {
            try
            {
                await goalService.CreateGoal(goal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var goal = await goalService.GetOneGoal(id);

            return View(goal);
        }

        [HttpPost]
        public async Task<ActionResult<Goal>> Edit(int id, Goal goal)
        {
            try
            {
                await goalService.Edit(id, goal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var goal = await goalService.GetOneGoal(id);

            return View(goal);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await goalService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
