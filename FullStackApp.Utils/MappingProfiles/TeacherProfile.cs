using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FullStackApp.DLL.Models;
using FullStackApp.Utils.DTOs;

namespace FullStackApp.Utils.MappingProfiles
{
    public class TeacherProfile : Profile
    {

        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();
        }
    }
}
