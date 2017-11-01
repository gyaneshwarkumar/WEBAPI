using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class SemisterEntity
    {
        public int Id { get; set; }
        public string Semister_Name { get; set; }
        public string Description { get; set; }
        public int Batch_Id { get; set; }
        public int Course_Id { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public string Del_Status { get; set; }
        public string App_Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
