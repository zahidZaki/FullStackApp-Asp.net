using AutoMapper;
using FullStackApp.DLL.Models;
using FullStackApp.Utils.DTOs;

namespace FullStackApp.Utils.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
