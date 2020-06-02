using DevelopingYou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public interface IInstanceService
    {
        Task<Instance> GetInstances();
        Task<Instance> GetInstanceById(int id);
        Task<Instance> Create(Instance instance);
        Task Delete(int id);
        Task<Instance> Edit(int id, Instance instance);
       

    }
}
