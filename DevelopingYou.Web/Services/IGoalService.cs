using DevelopingYou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public interface IGoalService
    {
        Task<List<Goal>> GetGoals();
        Task<Goal> CreateGoal(Goal goal);
        Task<Goal> GetOneGoal(int id);
    }
}
