using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;


 namespace IBusinessServices
{
    public interface ISemisterServices
    {
        SemisterEntity GetSemisterByID(int ID);
        IEnumerable<SemisterEntity> GetAllSemister();     
        int CreateSemister(SemisterEntity semisterentity);
        bool UpdateSemister(int ID,SemisterEntity semisterentity);
        bool DeleteSemister(int ID);

    }
}
