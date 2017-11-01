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
    public class SubCourseServices : ISubCourseServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public SubCourseServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public SubCourseEntity GetSubCourseById(int ID)
        {
            var Subcourses = _unitOfWork.SubcourseRepository.GetByID(ID);
            if (Subcourses != null)
            {
                return _mapper.Map<SubCourse, SubCourseEntity>(Subcourses);
            }
            return null;

        }

        public IEnumerable<SubCourseEntity> GetAllSubCourse()
        {

            var Subcourses = _unitOfWork.SubcourseRepository.GetAll().ToList();
            if (Subcourses.Any())
            {
                return _mapper.Map<List<SubCourse>, List<SubCourseEntity>>(Subcourses);

            }
            return null;

        }

        public int CreateSubCourse(SubCourseEntity subcourseEntity)
        {

            var model = _mapper.Map<SubCourseEntity, SubCourse>(subcourseEntity);

            _unitOfWork.SubcourseRepository.Insert(model);
            _unitOfWork.Save();
            return 0;
        }

        public bool UpdateSubCourse(int ID, SubCourseEntity subcourseEntity)
        {
            //var success = false;

            //if (subcourseEntity != null)
            //{
            //    var Subcourse = _unitOfWork.SubcourseRepository.GetByID(ID);
            //    if (Subcourse != null)
            //    {
            //        Subcourse.Id = subcourseEntity.Id;
            //        Subcourse.Sub_Course = subcourseEntity.Sub_Course;
            //        Subcourse.CourseId = subcourseEntity.CourseId;
            //        Subcourse.Description = subcourseEntity.Description;
            //        _unitOfWork.SubcourseRepository.Update(Subcourse);
            //        _unitOfWork.Save();
            //        success = true;
            //    }
            //}
            //return success;
            var SubCourse = _mapper.Map<SubCourseEntity, SubCourse>(subcourseEntity);
            var success = false;
            if (SubCourse != null && SubCourse.Id == ID)
            {
                if (SubCourse != null)
                {
                    _unitOfWork.SubcourseRepository.Update(SubCourse);
                    _unitOfWork.Save();
                    success = true;
                }

            }
            return success;
        }

        public bool DeleteSubCourse(int ID)
        {
            var success = false;
            if (ID > 0)
            {
                var Subcourse = _unitOfWork.SubcourseRepository.GetByID(ID);
                if (Subcourse != null)
                {

                    _unitOfWork.SubcourseRepository.Delete(Subcourse);
                    _unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

    }
}
