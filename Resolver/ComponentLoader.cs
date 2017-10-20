using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
//using System.ComponentModel.Composition.Hosting;
//using Autofac.Extensions.DependencyInjection;
//using System.ComponentModel.Composition.Hosting;
using Microsoft.AspNetCore.Hosting;
//using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Reflection.Metadata;

namespace Resolver
{
    public static class ComponentLoader
    {
        public static object ImportCardinality { get; private set; }

        public static void LoadContainer(IContainer container, string path, string pattern)
        {
            //var dirCat = new DirectoryCatalog(path, pattern);
            //var importDef = BuildImportDefinition();
            //try
            //{
            //    using (var aggregateCatalog = new AggregateCatalog())
            //    {
            //        aggregateCatalog.Catalogs.Add(dirCat);

            //        using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
            //        {
            //            IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);

            //            IEnumerable<IComponent> modules =
            //                exports.Select(export => export.Value as IComponent).Where(m => m != null);

            //            var registerComponent = new RegisterComponent(container);
            //            foreach (IComponent module in modules)
            //            {
            //                module.SetUp(registerComponent);
            //            }
            //        }
            //    }
            //}
            //catch (ReflectionTypeLoadException typeLoadException)
            //{
            //    var builder = new StringBuilder();
            //    foreach (Exception loaderException in typeLoadException.LoaderExceptions)
            //    {
            //        builder.AppendFormat("{0}\n", loaderException.Message);
            //    }

            //    throw new TypeLoadException(builder.ToString(), typeLoadException);
            //}
        }

        //private static ImportDefinition BuildImportDefinition()
        //{
        //    //return new ImportDefinition(
        //    //    def => true, typeof(IComponent).FullName, ImportCardinality.ZeroOrMore, false, false);
        //}
    }

    internal class RegisterComponent : IRegisterComponent
    {
        private readonly ContainerBuilder _container;

        public RegisterComponent(ContainerBuilder container)
        {
            this._container = container;
            //Register interception behaviour if any
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            {
                //register with interception 
            }
            else
            {
                this._container.RegisterType<TFrom>().As<TTo>();
                // _container.RegisterType<PushServive>().As<IPushServive>();
                // builder.RegisterType<PopService>().As<IPopService>();

                //var builder = new ContainerBuilder();
                //builder.RegisterType<PushServive>().As<IPushServive>();
                //builder.RegisterType<PopService>().As<IPopService>();
                //var container = builder.Build();

                //container.Resolve<IPushServive>().Execute();
                //container.Resolve<IPopService>().Execute();
                //Console.ReadLine();


                // this._container.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            this._container.RegisterType<TFrom>().As<TTo>().InstancePerLifetimeScope();
        }
    }
}
