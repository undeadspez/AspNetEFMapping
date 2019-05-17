using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.AutoMapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>();
        }
    }
}