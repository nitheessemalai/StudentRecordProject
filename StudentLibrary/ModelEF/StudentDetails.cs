﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLayer
{
   public class StudentDetails
    {
        [Key]

        public int StudentID { get; set;}

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }

        public long Moblie { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

    }
}
