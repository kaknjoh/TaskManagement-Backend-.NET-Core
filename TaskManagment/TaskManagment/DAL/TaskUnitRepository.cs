﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.AppData;
using TaskManagment.Models;

namespace TaskManagment.DAL
{
    public class TaskUnitRepository : ITaskUnitRepository
    {

       TaskManagementDbContext _context;
       public TaskUnitRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task DeleteTaskUnitAsync(TaskUnit taskUnit)
        {
            _context.Tasks.Remove(taskUnit);
            await _context.SaveChangesAsync();
        }

        public async Task EditTaskUnitAsync(TaskUnit taskUnit)
        {
            _context.Tasks.Update(taskUnit);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<TaskUnit>> GetAllTaskUnitsAsync()
        {
            return await _context.Tasks.AsNoTracking().Include(cs => cs.AssignedUserTaskUnits).ThenInclude( x=> x.AssignedUser).ToListAsync();
        }

        public async Task<TaskUnit> GetTaskUnitByIdAsync(int id)
        {
            return await _context.Tasks.AsNoTracking().Include(cs => cs.AssignedUserTaskUnits).ThenInclude(x=> x.AssignedUser).SingleOrDefaultAsync(cs => cs.TaskUnitId == id);
        }

        

        public async Task<TaskUnit> SaveTaskUnitAsync(TaskUnit taskUnit)
        {
            _context.Tasks.Add(taskUnit);
            await _context.SaveChangesAsync();
            return taskUnit;
            
        }
    }
}
