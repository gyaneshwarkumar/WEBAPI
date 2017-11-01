using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessServices
{
    public interface ISubCourseServices
    {
        SubCourseEntity GetSubCourseById(int ID);
        IEnumerable<SubCourseEntity> GetAllSubCourse();
        int CreateSubCourse(SubCourseEntity subcourseEntity);
        bool UpdateSubCourse(int ID, SubCourseEntity subcourseEntity);
        bool DeleteSubCourse(int ID);

    }
}
