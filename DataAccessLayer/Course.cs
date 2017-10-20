using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Course

    {
        [Key]
        public int Id { get; set; }
        public string Course_Name { get; set; }
        public string Description { get; set; }
        public string Del_Status { get; set; }
        public string App_Status { get; set; }
    }
}
