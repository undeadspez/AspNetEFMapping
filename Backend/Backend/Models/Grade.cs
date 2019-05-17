using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public float Value { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string SubjectName { get; set; }

        //[ForeignKey("Student")]
        //public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}