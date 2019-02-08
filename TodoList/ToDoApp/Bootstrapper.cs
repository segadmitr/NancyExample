using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Conventions;

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
