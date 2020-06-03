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

        public async Task<ActionResult> Details(int id)
        {
            var goal = await goalService.GetOneGoal(int id);
        }

        [HttpPut]
        public async Task<ActionResult<Goal>> Edit(int id)
        {
            return NoContent();
        }
    }
}
