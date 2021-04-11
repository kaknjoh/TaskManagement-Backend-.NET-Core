using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.AppData
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
           : base(options)
        {

        }

        public virtual DbSet<TaskUnit> Tasks { get; set; }
        public virtual DbSet<AssignedUser> AssignedUsers { get; set; }
        public virtual DbSet<AssignedUserTaskUnit> AssignedUserTaskUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedUserTaskUnit>()
            .HasKey(cs => new { cs.AssignedUserId, cs.TaskUnitId });

            modelBuilder.Entity<TaskUnit>().HasQueryFilter(x => !x.SoftDeleted);
        }

    }
}
