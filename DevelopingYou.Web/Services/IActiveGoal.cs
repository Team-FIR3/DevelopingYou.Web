using DevelopingYou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Services
{
    public interface IActiveGoal
    {
        Task<IEnumerable<Goal>> GetActiveGoals();
    }
}
