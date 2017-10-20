//using System.ComponentModel.Composition;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;
using IBusinessServices;
using Resolver;

namespace BusinessServices
{
   // [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<ICourseServices,CourseServices>();
            //registerComponent.RegisterType<IUserServices, UserServices>();
            //registerComponent.RegisterType<ITokenServices, TokenServices>();

        }
    }
}
