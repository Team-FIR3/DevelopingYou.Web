using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopingYou.Web.Models;
using DevelopingYou.Web.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<ActionResult> Create(Goal goal)
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
    }
}
