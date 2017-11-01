using DataAccessLayer.UnitOfWork;
using IBusinessServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using DataAccessLayer;
using System.Linq;

namespace BusinessServices
{
    public class SemisterServices: ISemisterServices
    {
        private readonly IUnitOfWork _Iunitofwork;
        private readonly IMapper _autoMapper;

        public SemisterServices(IUnitOfWork IUnitOfWork, IMapper IMapper)
        {
            _Iunitofwork = IUnitOfWork;
            _autoMapper = IMapper;
        }

        public SemisterEntity GetSemisterByID(int ID)
        {
            var sem = _Iunitofwork.SemisterRepository.GetByID(ID);
            if(sem != null)
            {
                return _autoMapper.Map<Semister, SemisterEntity>(sem);
            }
            return null;
        }

        public IEnumerable<SemisterEntity> GetAllSemister()
        {
            var sem1 = _Iunitofwork.SemisterRepository.GetAll().ToList();
            if(sem1.Any())
            {
                return _autoMapper.Map<List<Semister>, List<SemisterEntity>>(sem1);
            }
            return null;
        }

        public int CreateSemister(SemisterEntity SemisterEntity)
        {
            var sem2 = _autoMapper.Map<SemisterEntity,Semister>(SemisterEntity);
            _Iunitofwork.SemisterRepository.Insert(sem2);
            _Iunitofwork.Save();
             return 0;
        }

        public bool DeleteSemister(int ID)
        {
            var success = false;
            var checkTodelete = _Iunitofwork.SemisterRepository.GetByID(ID);
            if(checkTodelete != null)
            {
                _Iunitofwork.SemisterRepository.Delete(checkTodelete);
                _Iunitofwork.Save();
                success = true;
            }
            return success;
        }

        public bool UpdateSemister(int ID, SemisterEntity semisterentity)
        {
            var Toupdate = _autoMapper.Map<SemisterEntity,Semister>(semisterentity);
            var success = false;           
            if(Toupdate != null && Toupdate.Id > 0)
                {
                    _Iunitofwork.SemisterRepository.Update(Toupdate);
                    _Iunitofwork.Save();
                    success = true;
                }
            return success;
        }
            
        


   }
}
