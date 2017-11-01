

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Course> CourseRepository { get; }
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Batch> BatchRepository { get; }
        GenericRepository<SubCourse> SubcourseRepository { get; }
        GenericRepository<Semister> SemisterRepository { get; }
      //  GenericRepository<Student> StudentRepository { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save(); 
        #endregion
    }
}