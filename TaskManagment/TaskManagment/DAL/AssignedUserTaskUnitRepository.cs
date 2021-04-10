using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.AppData;
using TaskManagment.Models;

namespace TaskManagment.DAL
{
    public class AssignedUserTaskUnitRepository : IAssignedUserTaskUnitsRepository
    {
        private readonly TaskManagementDbContext _context;
        public AssignedUserTaskUnitRepository(TaskManagementDbContext context)
        {
            this._context = context;

        }
        public async Task AddAssignedUserTaskUnitsAsync(AssignedUserTaskUnit assignedUserTaskUnit)
        {
             _context.AssignedUserTaskUnits.Add(assignedUserTaskUnit);
             await _context.SaveChangesAsync();

        }

        public async Task DeleteAllAssignedUsersForTaskUnit(int taskUnit)
        {
            _context.AssignedUserTaskUnits.RemoveRange(_context.AssignedUserTaskUnits.Where(x => x.TaskUnitId == taskUnit));
            await _context.SaveChangesAsync();
        }
    }
}
