using BusinessEntities;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;
using IBusinessServices;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using System.Linq;
using System.Transactions;

namespace BusinessServices
{
 public   class CourseServices: ICourseServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CourseServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


      public  CourseEntity GetCourseById(int courseId)
        {

            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Course, CourseEntity>();
            //});

            var courses = _unitOfWork.CourseRepository.GetByID(courseId);
            if (courses != null)
            {
                return _mapper.Map<Course, CourseEntity>(courses);
            }
            return null;

        }

        public IEnumerable<CourseEntity> GetAllCourses()
        {

            var courses = _unitOfWork.CourseRepository.GetAll().ToList();
            if (courses.Any())
            {


                //var config = new MapperConfiguration(cfg => {
                //    cfg.CreateMap<Course, CourseEntity>();
                //});

             //   IMapper mapper = config.CreateMapper();
                // var source = new Source();
                return _mapper.Map< List<Course>, List< CourseEntity> >(courses);

            }
            return null;

        }

        public int CreateCourse(CourseEntity courseEntity)
        {
            /// var course = Mapper.Map<CourseEntity, Course>(courseEntity);
            /// 
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Course, CourseEntity>();
            //});

            //IMapper mapper = config.CreateMapper();
            //var model =  new Course()
            //{
            //    Course_Name = courseEntity.Course_Name,
            //    App_Status = courseEntity.App_Status,
            //    Description = courseEntity.Description,
            //    Del_Status = courseEntity.Del_Status
            //};

          var model=  _mapper.Map<CourseEntity, Course>(courseEntity);

            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<CourseEntity, Course>(courseEntity);
            //});


            //var tokenModel = new Course()
            //{
            //    Course_Name = "ttt",
            //   // App_Status = "1",
            //    Description = "desc"
            //  //  Del_Status = "1"
            //};

            //using (var scope = new TransactionScope())
            //{

          //  var vr = _mapper.Map<CourseEntity, Course>(courseEntity);
            _unitOfWork.CourseRepository.Insert(model);
                _unitOfWork.Save();
               // scope.Complete();
                return 0;
              
            //}
        }

        public bool UpdateCourse(int courseId, CourseEntity courseEntity)
        {

             var course = _mapper.Map<CourseEntity, Course>(courseEntity);
            var success = false;
            if (courseEntity != null && course.Id==courseId)
            {




                //using (var scope = new TransactionScope())
                //{
                //var course = _unitOfWork.CourseRepository.GetByID(courseId);
                    if (course != null)
                    {
                    //course.Course_Name = courseEntity.Course_Name;
                    //course.App_Status = courseEntity.App_Status;
                    //course.Description = courseEntity.Description;
                    //course.Del_Status = courseEntity.Del_Status;
                        _unitOfWork.CourseRepository.Update(course);
                        _unitOfWork.Save();
                       // scope.Complete();
                        success = true;
                    }
               // }
            }
            return success;
        }

        public bool DeleteCourse(int courseId)
        {
            var success = false;
            if (courseId > 0)
            {
                //using (var scope = new TransactionScope())
                //{
                    var course = _unitOfWork.CourseRepository.GetByID(courseId);
                    if (course != null)
                    {

                        _unitOfWork.CourseRepository.Delete(course);
                        _unitOfWork.Save();
                       // scope.Complete();
                        success = true;
                    }
               // }
            }
            return success;
        }

    }
}
