using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagment.Models
{
    public class AssignedUser
    {
        public AssignedUser()
        {
            this.TaskUnits = new HashSet<TaskUnit>();
        }
        public int AssignedUserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<TaskUnit> TaskUnits { get; set; }
    }
}
