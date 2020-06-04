using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public interface IActiveGoal
    {
        Task<List<Goal>> GetActiveGoals();
    }
}
