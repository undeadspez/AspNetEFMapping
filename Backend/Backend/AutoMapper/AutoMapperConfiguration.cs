using AutoMapper;

namespace Backend.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
                cfg.AddProfile<GradeProfile>();
            });
        }
    }
}