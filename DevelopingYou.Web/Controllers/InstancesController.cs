using DevelopingYou.Web.Models;
using DevelopingYou.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Controllers
{
    public class InstancesController : Controller
    {
        IInstanceService instanceService;

        public InstancesController(IInstanceService instance)
        {
            this.instanceService = instance;
        }
        //GET
        [Route("goals/{goalId}/instances")]
        public async Task<ActionResult> Index(int goalId)
        {
            var instances = await instanceService.GetInstances(goalId);
           

            return View(instances);
        }
        //Get instance
        public async Task<ActionResult> Details(int id)
        {
            var instance = await instanceService.GetInstanceById(id);
            return View(instance);
        }
        //GET: This is where we see the form
        [Route("goals/{goalId}/instances/create")]
        public ActionResult Create()
        {

            //this is what creates those calendars
            var instance = new Instance
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            return View(instance);
        }
        //POST Instance Create
        [HttpPost]
        [Route("goals/{goalId}/instances/create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Instance instance)
        {
            try
            {
                await instanceService.Create(instance);
                return RedirectToAction("Details", "Goals", new { Id = instance.GoalId });
                // Refactored one more line of code today Keith!!!!

            }
            catch
            {
                return View();
            }
        }

        //GET
        public async Task<ActionResult> Edit(int id)
        {
            var instance = await instanceService.GetInstanceById(id);
            return View(instance);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Instance instance)
        {
            try
            {
                await instanceService.Edit(id, instance);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
