using System;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;

namespace ToDoApp
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
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
    }
}
