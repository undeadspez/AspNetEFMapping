using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class StudentsService
    {
        public event Action<(int studentId, float average)> Calculated;

        public void Calc(IQueryable<Grade> grades)
        {
            var res = grades
                .AsParallel()
                .GroupBy(g => g.Student.StudentId)
                .Select(g => (g.Key, g.Average(x => x.Value)));

            foreach ((int, float) t in res)
            {
                Calculated?.Invoke(t);
            }
        }
    }
}