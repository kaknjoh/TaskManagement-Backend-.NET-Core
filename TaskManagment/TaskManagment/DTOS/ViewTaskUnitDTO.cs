using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagment.Models;

namespace TaskManagment.DTOS
{
    public class ViewTaskUnitDTO
    {
        public int TaskUnitId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<GetAssignedUserDTO> AssignedUsers { get; set; }
    }
}
