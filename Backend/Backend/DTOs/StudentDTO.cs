using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}