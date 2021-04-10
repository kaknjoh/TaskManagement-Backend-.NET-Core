using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public interface IAssignedUserTaskUnitService
    {
        public Task AddAssignedUserTaskUnit(AssignedUserTaskUnit assignedUserTaskUnit);

        public Task DeleteAllAssignedUsersForTaskUnit(int TaskUnit);
    }
}
