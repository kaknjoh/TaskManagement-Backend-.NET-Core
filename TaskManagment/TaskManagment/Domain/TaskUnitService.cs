using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.DAL;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public class TaskUnitService : ITaskUnitService
    {
        private readonly ITaskUnitRepository _taskUnitRepository;

        public TaskUnitService(ITaskUnitRepository taskUnitRepository)
        {
            this._taskUnitRepository = taskUnitRepository;
        }

        public async Task DeleteTaskUnitAsync(TaskUnit taskUnit)
        {
            await _taskUnitRepository.DeleteTaskUnitAsync(taskUnit);
        }

        public async Task EditTaskUnitAsync(TaskUnit taskUnitInDb, TaskUnit editTaskUnit)
        {
            taskUnitInDb.Name = editTaskUnit.Name;
            taskUnitInDb.Description = editTaskUnit.Description;
            taskUnitInDb.StartDate = editTaskUnit.StartDate;
            taskUnitInDb.EndDate = editTaskUnit.EndDate;
              await _taskUnitRepository.EditTaskUnitAsync(taskUnitInDb);
        }

        public Task<IEnumerable<TaskUnit>> GetAllTaskUnitsAsync()
        {
            return _taskUnitRepository.GetAllTaskUnitsAsync();
        }

        public  async Task<TaskUnit> GetTaskUnitByIdAsync(int id)
        {
            return await _taskUnitRepository.GetTaskUnitByIdAsync(id);
        }

        public  async Task SaveTaskUnitAsync(TaskUnit taskUnit)
        {
             await _taskUnitRepository.SaveTaskUnitAsync(taskUnit);
        }
    }
}
