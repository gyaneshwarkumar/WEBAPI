using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
   public class BatchEntity
    {
        public int Id { get; set; }
        public string Academic_Year { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Del_Status { get; set; }
        public string App_Status { get; set; }
        public int BatchInchargeId { get; set; }
        public int CourseId { get; set; }
        public int SubCourseId { get; set; }
        public int StartYear { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }
        public int PatternId { get; set; }
    }
}
