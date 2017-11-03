using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.UnitOfWork
{
    public interface IFunctionalUnitOfWork
    {
        GenericRepository<Student> StudentRepository { get; }

        void Save();
    }
}
