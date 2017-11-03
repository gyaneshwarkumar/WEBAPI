using DataAccessLayer.UnitOfWork;
using IBusinessServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using DataAccessLayer;
using System.Linq;

namespace BusinessServices
{
    public class StudentServices : IStudentServices
    {
        private readonly IFunctionalUnitOfWork _IFunctionalUnitOfWork;
        private readonly IMapper _autoMapper;

        public StudentServices(IFunctionalUnitOfWork IFunctionalUnitOfWork, IMapper IMapper)
        {
            _IFunctionalUnitOfWork = IFunctionalUnitOfWork;
            _autoMapper = IMapper;
        }

        public StudentEntity GetStudentByID(int ID)
        {
            var stud = _IFunctionalUnitOfWork.StudentRepository.GetByID(ID);
            if (stud != null)
            {
                return _autoMapper.Map<Student, StudentEntity>(stud);
            }
            return null;
        }

        public IEnumerable<StudentEntity> GetAllStudent()
        {
            var stud = _IFunctionalUnitOfWork.StudentRepository.GetAll().ToList();
            if (stud.Any())
            {
                return _autoMapper.Map<List<Student>, List<StudentEntity>>(stud);
            }
            return null;
        }

        public int CreateStudent(StudentEntity studententity)
        {
            var stud = _autoMapper.Map<StudentEntity, Student>(studententity);
            _IFunctionalUnitOfWork.StudentRepository.Insert(stud);
            _IFunctionalUnitOfWork.Save();
            return 0;
        }

        public bool DeleteStudent(int ID)
        {
            var success = false;
            var checkTodelete = _IFunctionalUnitOfWork.StudentRepository.GetByID(ID);
            if (checkTodelete != null)
            {
                _IFunctionalUnitOfWork.StudentRepository.Delete(checkTodelete);
                _IFunctionalUnitOfWork.Save();
                success = true;
            }
            return success;
        }

        public bool UpdateStudent(int ID, StudentEntity studententity)
        {
            var Toupdate = _autoMapper.Map<StudentEntity, Student>(studententity);
            var success = false;
            if (Toupdate != null && Toupdate.Id > 0)
            {
                _IFunctionalUnitOfWork.StudentRepository.Update(Toupdate);
                _IFunctionalUnitOfWork.Save();
                success = true;
            }
            return success;
        }




    }
}
