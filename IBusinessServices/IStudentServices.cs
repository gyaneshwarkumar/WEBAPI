using System;
using BusinessEntities;
using System.Collections.Generic;
using System.Text;

namespace IBusinessServices
{
    public interface IStudentServices
    {
        StudentEntity GetStudentByID(int ID);
        IEnumerable<StudentEntity> GetAllStudent();
        int CreateStudent(StudentEntity studententity);
        bool UpdateStudent(int ID, StudentEntity studententity);
        bool DeleteStudent(int ID);
    }
}
