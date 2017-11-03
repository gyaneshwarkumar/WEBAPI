#region Using Namespaces...

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Diagnostics;



#endregion

namespace DataAccessLayer.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class FunctionalUnitOfWork : IDisposable, IFunctionalUnitOfWork
    {
        #region Private member variables...

        private readonly FunctionalDbEntities _functionalContext = null;     
        private GenericRepository<Student> _StudentRepository;
        #endregion

        public FunctionalUnitOfWork()
        {
            _functionalContext = new FunctionalDbEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
       

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        
        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this._StudentRepository == null)
                    this._StudentRepository = new GenericRepository<Student>(_functionalContext);
                return _StudentRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _functionalContext.SaveChanges();
            }
            catch (Exception e)
            {

                var outputLines = new List<string>();
                //foreach (var eve in e.InnerException)
                //{
                //    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                //    }
                //}
                //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("FunctionalUnitOfWork is being disposed");
                    _functionalContext.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}