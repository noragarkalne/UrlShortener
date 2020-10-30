using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StructureMap;

namespace UrlShortener.DependencyResolution
{
    public class StructureMapDependencyResolver : StructureMapApiScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container) : base(container)
        {
            _container = container ?? throw new ArgumentException(nameof(container));
        }

        private readonly IContainer _container;

        public IDependencyScope BeginScope()
        {
            var childContainer = _container.GetNestedContainer();
            return new StructureMapApiScope(childContainer);
        }
    }
}