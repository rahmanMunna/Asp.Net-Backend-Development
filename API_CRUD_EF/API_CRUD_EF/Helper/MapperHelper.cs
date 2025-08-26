using API_CRUD_EF.DTO;
using API_CRUD_EF.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD_EF.Helper
{
    public class MapperHelper
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student,StudentDTO>().ReverseMap();   
                cfg.CreateMap<Department,DepartmentDTO>().ReverseMap();   
                cfg.CreateMap<Student,StudentDepartmentDTO>().ReverseMap();   
                cfg.CreateMap<Department,DepartmentStudentDTO>().ReverseMap();   
            });

            var mapper = new Mapper(config);
            return mapper;  
        }
    }
}