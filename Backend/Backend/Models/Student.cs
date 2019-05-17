using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public StudentDetails StudentDetails { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}