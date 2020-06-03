using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using DevelopingYou.Web.Models;
using DevelopingYou.Web.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> Index()
        {
            var instances = await instanceService.GetInstances();
            //Add orderby maybe?

            return View();
        }
        //Get instance
        public async Task<ActionResult> Details(int id)
        {
            var instance = await instanceService.GetInstanceById(id);
            return View(instance);
        }
        //GET: This is where we see the form
        public ActionResult Create()
        {
            return View();
        }
        //POST Instance Create
        public async Task<ActionResult> Create(Instance instance)
        {
            try
            {
                await instanceService.Create(instance);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        //GET
        public async Task<ActionResult> Edit (int id)
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
