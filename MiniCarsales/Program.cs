using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MiniCarsales.Modules;
using MiniCarsales.Services;

namespace MiniCarsales
{
    public class Program
    {
        static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<VehicleService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterModule(new PerRequestModule());
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
