

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Course> CourseRepository { get; }
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Batch> BatchRepository { get; } 

        #endregion
        
        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save(); 
        #endregion
    }
}