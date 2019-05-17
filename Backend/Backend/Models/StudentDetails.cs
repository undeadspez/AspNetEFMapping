using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class StudentDetails
    {
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Height { get; set; }

        public float Weight { get; set; }

        public Student Student { get; set; }
    }
}