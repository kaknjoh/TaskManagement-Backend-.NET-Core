using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.Domain
{
    public interface IAssignedUserService
    {
        public Task<IEnumerable<AssignedUser>> GetAllAssignedUsersAsync();

        public Task SaveAssignedUserAsync(AssignedUser assignedUser);

        public Task<AssignedUser> GetAssignedUserByIdAsync(int id);

        public Task EditAssignedUserAsync(AssignedUser assignedUserInDb, AssignedUser assignedUser);

        public Task DeleteAssignedUserAsync(AssignedUser assignedUser);
    }
}
