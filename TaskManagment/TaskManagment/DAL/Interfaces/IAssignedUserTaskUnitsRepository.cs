using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.DAL
{
    public interface IAssignedUserTaskUnitsRepository
    {
        public Task AddAssignedUserTaskUnitsAsync(AssignedUserTaskUnit assignedUserTaskUnit);
        public Task DeleteAllAssignedUsersForTaskUnit(int TaskUnit);
    }
}
