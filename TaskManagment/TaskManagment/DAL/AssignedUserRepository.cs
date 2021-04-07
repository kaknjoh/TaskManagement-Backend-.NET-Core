using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.AppData;
using TaskManagment.Models;

namespace TaskManagment.DAL
{
    public class AssignedUserRepository : IAssignedUserRepository
    {
        TaskManagementDbContext _context;

        public AssignedUserRepository(TaskManagementDbContext context)
        {
            this._context = context;
        }

        public async Task DeleteAssignedUserAsync(AssignedUser assignedUser)
        {
            _context.AssignedUsers.Remove(assignedUser);
            await _context.SaveChangesAsync();
        }

        public async Task EditAssignedUserAsync(AssignedUser assignedUser)
        {
            _context.AssignedUsers.Update(assignedUser);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AssignedUser>> GetAllAssignedUsersAsync()
        {
            return await _context.AssignedUsers.ToListAsync();
        }

        public async Task<AssignedUser> GetAssignedUserByIdAsync(int id)
        {
            return await _context.AssignedUsers.SingleOrDefaultAsync(c => c.AssignedUserId == id);
        }

        public async Task SaveAssignedUserAsync(AssignedUser assignedUser)
        {
            _context.AssignedUsers.Add(assignedUser);
            await _context.SaveChangesAsync();
        }
    }
}
