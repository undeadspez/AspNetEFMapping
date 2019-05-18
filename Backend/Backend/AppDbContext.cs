using Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Backend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Default")
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<StudentDetails>().ToTable("Students");

            modelBuilder.Entity<Grade>()
                .Map(m =>
                {
                    m.Properties(g => new { g.Value, g.Type, g.Date });
                    m.ToTable("Grades");
                })
                .Map(m =>
                {
                    m.Property(g => g.SubjectName);
                    m.ToTable("Subjects");
                })
                .HasRequired(g => g.Student)
                .WithMany(s => s.Grades)
                .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        private Random random = new Random();

        private string GetPath(string fileName) =>
            HostingEnvironment.MapPath($"~/App_Data/{fileName}.csv");

        private List<string> ReadLines(string path, int count) =>
            File.ReadAllLines(GetPath(path)).Skip(1).Take(count).ToList();

        private DateTime ParseDate(string date) =>
            DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture);

        protected override void Seed(AppDbContext context)
        {
            List<string> studentsLines = ReadLines("students", 100);
            List<Student> students = new List<Student>();

            foreach (string line in studentsLines)
            {
                string[] cols = line.Split(',');
                students.Add(new Student
                {
                    Name = cols[0],
                    Email = cols[1],
                    StudentDetails = new StudentDetails
                    {
                        DateOfBirth = ParseDate(cols[2]),
                        Height = decimal.Parse(cols[3]),
                        Weight = float.Parse(cols[4])
                    }
                });
            }

            context.Students.AddRange(students);
            context.SaveChanges();

            int studentsCount = students.Count;
            List<string> gradesLines = ReadLines("grades", 100);
            List<Grade> grades = new List<Grade>();

            foreach (string line in gradesLines)
            {
                string[] cols = line.Split(',');
                grades.Add(new Grade
                {
                    Value = int.Parse(cols[0]),
                    Type = cols[1],
                    Date = ParseDate(cols[2]),
                    SubjectName = cols[3],
                    Student = students[random.Next(studentsCount)]
                });
            }

            context.Grades.AddRange(grades);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}