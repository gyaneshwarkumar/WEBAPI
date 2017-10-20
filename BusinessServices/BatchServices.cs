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

        /// <summary>
        /// Public constructor.
        /// </summary>
        public BatchServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        //public IEnumerable<CourseEntity> GetAllBatches()

        //{
        //    var courses = _unitOfWork.CourseRepository.GetAll().ToList();
        //    if (courses.Any())
        //    {
        //        // Mapper.CreateMap<Course, ProductEntity>();
        //        var productsModel = Mapper.Map<List<Batch>, List<CourseEntity>>(courses);
        //        return productsModel;
        //    }
        //    return null;
        //}



    }
}
