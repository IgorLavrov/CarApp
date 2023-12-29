using CarApp.ApplicationServices.Services;
using CarApp.CarAppTest.Macro;
using CarApp.CarAppTest.Mock;
using CarApp.Core.ServiceInterface;
using CarApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.CarAppTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; }

        protected TestBase()
        {
            var service = new ServiceCollection();
            SetupServices(service);
            serviceProvider=service.BuildServiceProvider();
        }


        protected T Macro<T>() where T : IMacro
        {
            return serviceProvider.GetService<T>();

        }

        protected T Svc<T>()
        {

            return serviceProvider.GetService<T>();



        }

        public void Dispose()
        {

        }



        public virtual void SetupServices(IServiceCollection service)
        {
            service.AddScoped<ICarAppServices, CarAppServices>();
            service.AddScoped<IHostEnvironment, MockIHostEnviroment>();


            service.AddDbContext<CarAppContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            });

            RegisterMacros(service);

        }

        private void RegisterMacros(IServiceCollection service)
        {
            var macroBaseType = typeof(TestBase);
            var macros = macroBaseType.Assembly.GetTypes()
                    .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface
                    && !x.IsAbstract);
            foreach (var macro in macros)
            {
                service.AddSingleton(macro);
            }


        }




    }
}
