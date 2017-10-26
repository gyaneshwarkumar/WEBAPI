using BusinessEntities;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;
using IBusinessServices;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using System.Linq;

namespace BusinessServices
{
    public class BatchServices : IBatchServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        /// <summary>
        /// Public constructor.
        /// </summary>
        public BatchServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int CreateBatch(BatchEntity batchEntity)
        {
            var model = _mapper.Map<BatchEntity, Batch>(batchEntity);


            _unitOfWork.BatchRepository.Insert(model);
            _unitOfWork.Save();

            return 0;

        }

        public bool DeleteBatch(int batchId)
        {
            var success = false;
            if (batchId > 0)
            {
                //using (var scope = new TransactionScope())
                //{
                var batch = _unitOfWork.BatchRepository.GetByID(batchId);
                if (batch != null)
                {

                    _unitOfWork.BatchRepository.Delete(batch);
                    _unitOfWork.Save();
                    success = true;
                }
                // }
            }
            return success;
        }

        public IEnumerable<BatchEntity> GetAllBatches()
        {
            var batches = _unitOfWork.BatchRepository.GetAll().ToList();
            if (batches.Any())
            {
                return _mapper.Map<List<Batch>, List<BatchEntity>>(batches);

            }
            return null;
        }

        public BatchEntity GetBatchById(int batchId)
        {


            var batch = _unitOfWork.BatchRepository.GetByID(batchId);
            if (batch != null)
            {
                // Mapper.CreateMap<Course, CourseEntity>();
                var batchModel = Mapper.Map<Batch, BatchEntity>(batch);
                return batchModel;
            }
            return null;

        }

        public bool UpdateBatch(int batchId, BatchEntity batchEntity)

        {
            var success = false;
            if (batchEntity != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var batch = _unitOfWork.BatchRepository.GetByID(batchId);
                if (batch != null)
                {
                    batch.Batch_Name = batchEntity.Batch_Name;
                    batch.App_Status = batchEntity.App_Status;
                    batch.Description = batchEntity.Description;
                    batch.Del_Status = batchEntity.Del_Status;
                    batch.Course_Id = batchEntity.Course_Id;
                    batch.Acedemic_Year = batchEntity.Acedemic_Year;

                    _unitOfWork.BatchRepository.Update(batch);
                    _unitOfWork.Save();
                    // scope.Complete();
                    success = true;
                }
                // }
            }
            return success;
        }

    }
}
