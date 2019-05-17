using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.AutoMapper
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, GradeDTO>()
                .ForMember("StudentId", m => m.MapFrom(g => g.Student.StudentId));
        }
    }
}