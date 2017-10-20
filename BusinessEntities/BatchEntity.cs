using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
   public class BatchEntity
    {
        public int Id { get; set; }
        public string Batch_Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Course_Id { get; set; }
        public string Del_Status { get; set; }
        public string App_Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<int> Acedemic_Year { get; set; }
    }
}
