﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagment.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        
    }
}
