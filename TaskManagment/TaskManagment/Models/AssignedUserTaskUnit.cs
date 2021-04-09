using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagment.Models
{
    public class AssignedUserTaskUnit
    {
        public int AssignedUserId { get; set; }
        public  AssignedUser AssignedUser {get; set;}
        public int TaskUnitId { get; set; }
        public TaskUnit TaskUnit { get; set; }
    }
}
