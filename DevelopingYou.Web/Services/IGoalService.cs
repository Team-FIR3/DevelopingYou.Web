using DevelopingYou.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public interface IGoalService
    {
        Task<List<Goal>> GetGoals();
        Task<Goal> CreateGoal(Goal goal);
        Task<Goal> GetOneGoal(int id);
        Task<Goal> Edit(int id, Goal goal);
        Task Delete(int id);
        Task<List<Goal>> GetActiveGoals();
    }
}
