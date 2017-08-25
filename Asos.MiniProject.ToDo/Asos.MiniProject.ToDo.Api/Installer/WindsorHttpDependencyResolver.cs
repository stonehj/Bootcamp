namespace Asos.MiniProject.ToDo.Api.Installer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using Castle.Windsor;

    public class WindsorHttpDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer container;
        private bool isDisposed;

        public WindsorHttpDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        ~WindsorHttpDependencyResolver()
        {
            this.Dispose(false);
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container);
        }

        public object GetService(Type serviceType)
        {
            return this.container.Kernel.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            if (disposing)
            {
                this.container.Dispose();
            }

            this.isDisposed = true;
        }
    }
}