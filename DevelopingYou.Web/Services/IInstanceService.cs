using DevelopingYou.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public interface IInstanceService
    {
        Task<IEnumerable<Instance>> GetInstances(int goalId);
        Task<Instance> GetInstanceById(int id);
        Task<Instance> Create(Instance instance);
        Task Delete(int id);
        Task<Instance> Edit(int id, Instance instance);


    }
}
