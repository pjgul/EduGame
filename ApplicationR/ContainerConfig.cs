using Autofac;
using System;
using DomainR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationR
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Arguments>().As<IArguments<int>>();
            builder.RegisterType<Health>().As<IHealth>();
            builder.RegisterType<EquationsInt>().As<IEquationsInt>();

            return builder.Build();
        }
    }
}
