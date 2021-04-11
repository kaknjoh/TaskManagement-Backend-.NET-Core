using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.DAL
{
    public interface ITaskUnitRepository
    {
        Task<IList<TaskUnit>> GetAllTaskUnitsAsync();

        Task<TaskUnit> SaveTaskUnitAsync(TaskUnit taskUnit);

        Task<TaskUnit> GetTaskUnitByIdAsync(int id);

        Task EditTaskUnitAsync(TaskUnit taskUnit);

        Task DeleteTaskUnitAsync(TaskUnit taskUnit);

        Task SoftDeleteTaskUnitAsync(int id);

        Task GetBackSoftDeleteTaskUnitByIdAsync(int id);

        Task<IList<TaskUnit>> GetAllSoftDeletedTaskUnitsAsync();
    }
}
