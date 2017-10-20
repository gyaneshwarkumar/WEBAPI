using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessServices
{
  public interface   ICourseServices
    { 
          CourseEntity GetCourseById(int courseId);

    IEnumerable<CourseEntity> GetAllCourses();
    int CreateCourse(CourseEntity batchEntity);
    bool UpdateCourse(int batchId, CourseEntity productEntity);
    bool DeleteCourse(int batchId);
}

}