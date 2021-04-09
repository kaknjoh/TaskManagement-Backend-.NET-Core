using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.DAL;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public class AssignedUserTaskUnitService : IAssignedUserTaskUnitService
    {
        private readonly IAssignedUserTaskUnitsRepository _assignedUserTaskUnitsRepository;
        public AssignedUserTaskUnitService(IAssignedUserTaskUnitsRepository assignedUserTaskUnitsRepository)
        {
            this._assignedUserTaskUnitsRepository = assignedUserTaskUnitsRepository;
        }
        public async Task AddAssignedUserTaskUnit(AssignedUserTaskUnit assignedUserTaskUnit)
        {
            await _assignedUserTaskUnitsRepository.AddAssignedUserTaskUnitsAsync(assignedUserTaskUnit);
        }

        public async Task DeleteAllAssignedUsersForTaskUnit(int taskUnit)
        {
            await _assignedUserTaskUnitsRepository.DeleteAllAssignedUsersForTaskUnit(taskUnit);
        }
    }
}
