using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Course_Name { get; set; }
        public string Description { get; set; }
        public string Del_Status { get; set; }
        public string App_Status { get; set; }
    }
}
