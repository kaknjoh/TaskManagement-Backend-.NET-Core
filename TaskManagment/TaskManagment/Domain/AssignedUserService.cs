using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.DAL;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public class AssignedUserService : IAssignedUserService
    {
        private readonly IAssignedUserRepository _assignedUserRepository;

        public AssignedUserService(IAssignedUserRepository assignedUserRepository)
        {
            _assignedUserRepository = assignedUserRepository;
        }

        public Task DeleteAssignedUserAsync(AssignedUser assignedUser)
        {
            return  _assignedUserRepository.DeleteAssignedUserAsync(assignedUser);
        }

        public Task EditAssignedUserAsync(AssignedUser assignedUserInDb, AssignedUser assignedUser)
        {
           assignedUserInDb.FirstName = assignedUser.FirstName;
           assignedUserInDb.LastName = assignedUser.LastName;
           return _assignedUserRepository.EditAssignedUserAsync(assignedUserInDb);
        }

        public Task<IEnumerable<AssignedUser>> GetAllAssignedUsersAsync()
        {
            return _assignedUserRepository.GetAllAssignedUsersAsync();
        }

        public Task<AssignedUser> GetAssignedUserByIdAsync(int id)
        {
            return _assignedUserRepository.GetAssignedUserByIdAsync(id);
        }

        public Task SaveAssignedUserAsync(AssignedUser assignedUser)
        {
            return _assignedUserRepository.SaveAssignedUserAsync(assignedUser);
        }
    }
}

