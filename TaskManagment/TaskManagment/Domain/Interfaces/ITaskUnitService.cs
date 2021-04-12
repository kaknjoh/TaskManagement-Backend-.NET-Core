using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.DTOS;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public interface ITaskUnitService
    {

        public  Task<IList<ViewTaskUnitDTO>> GetAllTaskUnitsAsync();

        public Task<TaskUnitDTO> SaveTaskUnitAsync(TaskUnitDTO taskUnitDto);

        public Task<ViewTaskUnitDTO> GetTaskUnitByIdAsync(int id);

        public Task EditTaskUnitAsync(TaskUnitDTO editTaskUnit );

        public Task DeleteTaskUnitAsync(ViewTaskUnitDTO taskUnit);

        public Task SoftDeleteTaskUnitAsync(int id);

        public Task<ViewTaskUnitDTO>  GetBackSoftDeletedTaskUnitByIdAsync(int id);

        public Task<IList<ViewTaskUnitDTO>> GetAllSoftDeletedTaskUnitsAsync();

    }
}
