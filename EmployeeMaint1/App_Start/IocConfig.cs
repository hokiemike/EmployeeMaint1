using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using EmployeeMaint.Data.Repository;


namespace EmployeeMaint1
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            //kernel.Bind<ISessionHelper>().To<SessionHelper>()
            //    .InSingletonScope();

            //kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            //kernel.Bind<ITaskRepository>().To<TaskRepository>();
            //kernel.Bind<ILookupsRepository>().To<LooksupsRepository>();
            //kernel.Bind<ILookupsUow>().To<LookupsUow>();


            kernel.Bind<IEmpRepository>().To<EmpRepository>();



            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
        }
    }
}