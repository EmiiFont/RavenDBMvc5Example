using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Raven.Client;
using Raven.Client.Document;
using Raven.DataLayer;


[assembly: WebActivator.PreApplicationStartMethod(typeof(MongoDBMvc5.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MongoDBMvc5.App_Start.NinjectWebCommon), "Stop")]
[assembly: WebActivator.PostApplicationStartMethod(typeof(MongoDBMvc5.App_Start.NinjectWebCommon), "PostStart")]
namespace MongoDBMvc5.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
            
        }
        public static void PostStart()
        {
            //Force hack to set the culture again to the one defined on the web.config


        }
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
            return kernel;
        }
        
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDocumentStoreFactory>()
                .To<DocumentStoreFactory>().InSingletonScope()
                .WithConstructorArgument("connectionString", "ravenDB");

            kernel.Bind<IDocumentSession>().ToMethod(context => context.Kernel.Get<IDocumentStoreFactory>().Get().OpenSession()).InRequestScope();
            kernel.Bind<IItemService>().To<ItemService>().InTransientScope();
        }        
    }
}
