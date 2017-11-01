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
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private readonly DbEntities _context = null;
      //  private readonly DbContextOptions _DbContextOptions = null;

        
        private GenericRepository<User> _userRepository;
        private GenericRepository<Course> _courseRepository;
        private GenericRepository<Batch> _batchRepository;
        private GenericRepository<SubCourse> _SubcourseRepository;
        private GenericRepository<Semister> _SemisterRepository;
       // private GenericRepository<Student> _StudentRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new DbEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(_context);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Course> CourseRepository

        {
            get
            {
                if (this._courseRepository == null)
                    this._courseRepository = new GenericRepository<Course>(_context);
                return _courseRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<Batch> BatchRepository
        {
            get
            {
                if (this._batchRepository == null)
                    this._batchRepository = new GenericRepository<Batch>(_context);
                return _batchRepository;
            }
        }     
        
        public GenericRepository<SubCourse> SubcourseRepository
        {
            get
            {
                if (this._SubcourseRepository == null)
                    this._SubcourseRepository = new GenericRepository<SubCourse>(_context);
                return _SubcourseRepository;
            }
        }

        public GenericRepository<Semister> SemisterRepository
        {
            get
            {
                if (this._SemisterRepository == null)
                    this._SemisterRepository = new GenericRepository<Semister>(_context);
                return _SemisterRepository;
            }
        }

        //public GenericRepository<Student> StudentRepository
        //{
        //    get
        //    {
        //        if (this._StudentRepository == null)
        //            this._StudentRepository = new GenericRepository<Student>(_context);
        //         return _StudentRepository;
        //    }
        //}
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
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
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
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