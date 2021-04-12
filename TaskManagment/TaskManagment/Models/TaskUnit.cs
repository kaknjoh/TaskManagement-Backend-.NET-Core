using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagment.Models
{
    public class TaskUnit
    {
        [Key]
        public int TaskUnitId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool SoftDeleted { get; set; }

        public ICollection<AssignedUserTaskUnit> AssignedUserTaskUnits { get; set; }

        
    }
}
