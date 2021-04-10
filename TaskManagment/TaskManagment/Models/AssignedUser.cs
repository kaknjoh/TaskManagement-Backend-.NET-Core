using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManagment.Models
{
    public class AssignedUser
    {
        
        public int AssignedUserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<AssignedUserTaskUnit> AssignedUserTaskUnits { get; set; }
    }
}
