using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public interface ITaskUnitService
    {

        public  Task<IEnumerable<TaskUnit>> GetAllTaskUnitsAsync();

        public Task SaveTaskUnitAsync(TaskUnit taskUnit);

        public Task<TaskUnit> GetTaskUnitByIdAsync(int id);

        public Task EditTaskUnitAsync(TaskUnit taskUnitInDb , TaskUnit editTaskUnit );

        public Task DeleteTaskUnitAsync(TaskUnit taskUnit);

    }
}
