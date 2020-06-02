using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using DevelopingYou.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevelopingYou.Web.Controllers
{
    public class InstancesController : Controller
    {
        IInstanceService instanceService;

        public InstancesController(IInstanceService instance)
        {
            this.instanceService = instanceService;
        }
         //GET
         public async Task<ActionResult> Index()
        {
            var instances = await instanceService.GetInstances();
            return View(instances.OrderBy(instances => instances.Id));
        }

       
    }
}
