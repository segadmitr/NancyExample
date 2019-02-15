using System;
using System.Configuration;
using AutoMapper;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using ToDoApp.Core.Interfaces;
using ToDoApp.Infrastructure.Linq2DbData;
/*Раскоментить/закоментить если нужно работать через EntityFramework
using ToDoApp.Infrastructure.EntityFramework;*/
using ToDoApp.Infrastructure.Linq2DbData.MapConfigs;
using ToDoApp.Logic.Implementation;
using ToDoApp.Logic.Interfaces;

namespace ToDoApp
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            Mapper.Initialize(cfg =>
            {
                //Профиль для linq2db(убрать если не нужно)
                cfg.AddProfile<Linq2DbMapProfile>();
            });

            base.ApplicationStartup(container, pipelines);
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            IDisposable scope = null;

            pipelines.BeforeRequest += ctx =>
            {
                scope = container.BeginScope();
                return ctx.Response;
            };

            pipelines.AfterRequest += ctx =>
            {
                if (scope != null)
                {
                    scope.Dispose();
                    scope = null;
                }
            };

            pipelines.OnError += (ctx, ex) =>
            {
                if (scope != null)
                {
                    scope.Dispose();
                    scope = null;
                }
                return null;
            };
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(
                Component.For<IUnitOfWork>()
                    .ImplementedBy<UnitOfWork>()
                    .DependsOn(Dependency.OnValue<string>(ConfigurationManager.ConnectionStrings["TodoBd"].ConnectionString))
                    .LifestyleTransient()
            );

            container.Register(
                Component.For<IToDoItemService>()
                    .ImplementedBy<ToDoItemService>()
                    .LifestyleTransient()
            );
        }
    }
}
