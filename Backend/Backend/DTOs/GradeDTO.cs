using System;

namespace Backend.DTOs
{
    public class GradeDTO
    {
        public int GradeId { get; set; }

        public float Value { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string SubjectName { get; set; }

        public int StudentId { get; set; }
    }
}