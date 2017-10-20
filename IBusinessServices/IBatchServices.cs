using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessServices
{
   public interface  IBatchServices
    {
        BatchEntity GetBatchById(int batchId);
       // IEnumerable<BatchEntity> GetAllBatches();
        //int CreateBatch(BatchEntity batchEntity);
        //bool UpdateBatch(int batchId, BatchEntity productEntity);
        //bool DeleteBatch(int batchId);
    }

}
