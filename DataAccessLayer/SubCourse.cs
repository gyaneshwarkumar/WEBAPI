using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class SubCourse

    {
        [Key]
        public int Id { get; set; }
        public string Sub_Course { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
       
    }
}
