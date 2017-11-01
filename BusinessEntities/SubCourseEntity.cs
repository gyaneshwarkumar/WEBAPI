using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class SubCourseEntity
    {
        public int Id { get; set; }
        public string Sub_Course { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
    }
}
