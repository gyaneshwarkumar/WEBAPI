using AutoMapper;
using BusinessEntities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Course, CourseEntity>();
            CreateMap<CourseEntity, Course>();

            CreateMap<Batch, BatchEntity>();
            CreateMap<BatchEntity, Batch>();

            CreateMap<SubCourse, SubCourseEntity>();
            CreateMap<SubCourseEntity, SubCourse>();

            CreateMap<Semister, SemisterEntity>();
            CreateMap<SemisterEntity, Semister>();

            CreateMap<Student, StudentEntity>();
            CreateMap<StudentEntity, Student>();
        }
    }
}
