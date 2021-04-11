using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.DAL;
using TaskManagment.DTOS;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public class TaskUnitService : ITaskUnitService
    {
        private readonly ITaskUnitRepository _taskUnitRepository;
        private readonly IAssignedUserService _assignedUserService;
        private readonly IMapper _mapper;
        private readonly IAssignedUserTaskUnitService _assignedUserTaskUnitService;

        public TaskUnitService(ITaskUnitRepository taskUnitRepository, IAssignedUserService assignedUserService, IMapper mapper, IAssignedUserTaskUnitService assignedUserTaskUnitService)
        {
            this._taskUnitRepository = taskUnitRepository;
            this._assignedUserService = assignedUserService;
            this._mapper = mapper;
            this._assignedUserTaskUnitService = assignedUserTaskUnitService;
        }

        public async Task DeleteTaskUnitAsync(ViewTaskUnitDTO taskUnit)
        {
            
            await _taskUnitRepository.DeleteTaskUnitAsync(_mapper.Map<ViewTaskUnitDTO, TaskUnit>(taskUnit));
        }

        public async Task EditTaskUnitAsync(TaskUnitDTO editTaskUnit)
        {
            TaskUnit taskUnit = _mapper.Map<TaskUnitDTO, TaskUnit>(editTaskUnit);
            await _assignedUserTaskUnitService.DeleteAllAssignedUsersForTaskUnit(taskUnit.TaskUnitId);
            TaskUnit taskUnitInDb = await _taskUnitRepository.GetTaskUnitByIdAsync(taskUnit.TaskUnitId);
            var assignedUsers = editTaskUnit.AssignedUsers;
            if (assignedUsers != null)
            {
                for (int i = 0; i < assignedUsers.Count(); i++)
                {
                    int assignedUserId = Int32.Parse(assignedUsers.ElementAt(i));
                    AssignedUser assignedUser = await _assignedUserService.GetAssignedUserByIdAsync(assignedUserId);

                    AssignedUserTaskUnit assignedUserTaskUnit = new AssignedUserTaskUnit
                    {
                        AssignedUserId = assignedUser.AssignedUserId,
                        TaskUnitId = taskUnitInDb.TaskUnitId
                    };
                    await _assignedUserTaskUnitService.AddAssignedUserTaskUnit(assignedUserTaskUnit);
                }
            }

            await _taskUnitRepository.EditTaskUnitAsync(taskUnit);
        }

        public async Task<IList<ViewTaskUnitDTO>> GetAllSoftDeletedTaskUnitsAsync()
        {
            IList<TaskUnit> result = await _taskUnitRepository.GetAllSoftDeletedTaskUnitsAsync();
            IList<ViewTaskUnitDTO> taskUnitDTOs = new List<ViewTaskUnitDTO>();
            ViewTaskUnitDTO tempTaskUnitDTO;
            for (int i = 0; i < result.Count(); i++)
            {
                tempTaskUnitDTO = _mapper.Map<TaskUnit, ViewTaskUnitDTO>(result.ElementAt(i));
                taskUnitDTOs.Add(tempTaskUnitDTO);
            }

            return taskUnitDTOs;
        }

        public async Task<IList<ViewTaskUnitDTO>> GetAllTaskUnitsAsync()
        {
            IList<TaskUnit> result = await _taskUnitRepository.GetAllTaskUnitsAsync();
            IList<ViewTaskUnitDTO> taskUnitDTOs = new List<ViewTaskUnitDTO>();
            ViewTaskUnitDTO tempTaskUnitDTO;
            for(int i=0; i < result.Count(); i++)
            {
                tempTaskUnitDTO=_mapper.Map<TaskUnit, ViewTaskUnitDTO>(result.ElementAt(i));
                taskUnitDTOs.Add(tempTaskUnitDTO);
            }

            return taskUnitDTOs;
        }

        public async Task<ViewTaskUnitDTO>  GetBackSoftDeletedTaskUnitByIdAsync(int id)
        {
             await _taskUnitRepository.GetBackSoftDeleteTaskUnitByIdAsync(id);
            return _mapper.Map<TaskUnit, ViewTaskUnitDTO>(await _taskUnitRepository.GetTaskUnitByIdAsync(id));
        }

        public  async Task<ViewTaskUnitDTO> GetTaskUnitByIdAsync(int id)
        {
            return _mapper.Map<TaskUnit, ViewTaskUnitDTO>( await _taskUnitRepository.GetTaskUnitByIdAsync(id));
        }

        public  async Task<TaskUnitDTO> SaveTaskUnitAsync(TaskUnitDTO taskUnitDto)
        {
            TaskUnit taskUnit = _mapper.Map<TaskUnitDTO, TaskUnit>(taskUnitDto);
            taskUnit.SoftDeleted = false;
            
            TaskUnitDTO taskUnitD= _mapper.Map<TaskUnit, TaskUnitDTO>(await _taskUnitRepository.SaveTaskUnitAsync(taskUnit));

            var assignedUsers = taskUnitDto.AssignedUsers;
            if(assignedUsers != null)
            {
                for (int i = 0; i < assignedUsers.Count(); i++)
                {
                    int assignedUserId = Int32.Parse(assignedUsers.ElementAt(i));
                    AssignedUser assignedUser = await _assignedUserService.GetAssignedUserByIdAsync(assignedUserId);

                    AssignedUserTaskUnit assignedUserTaskUnit = new AssignedUserTaskUnit
                    {
                        AssignedUser= assignedUser,
                        TaskUnit = taskUnit
                    };
                    await _assignedUserTaskUnitService.AddAssignedUserTaskUnit(assignedUserTaskUnit);
                }
            }
            return taskUnitDto;
        }
        public async Task SoftDeleteTaskUnitAsync(int id)
        {
            _taskUnitRepository.SoftDeleteTaskUnitAsync(id);
        }
    }
}
