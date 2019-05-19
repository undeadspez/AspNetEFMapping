using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        [Required]
        public float Value { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string SubjectName { get; set; }

        //[ForeignKey("Student")]
        //public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}