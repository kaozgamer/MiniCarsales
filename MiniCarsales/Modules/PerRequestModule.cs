using Autofac;
using Autofac.Integration.WebApi;
using MiniCarsales.Controllers;
using System.Reflection;

namespace MiniCarsales.Modules
{
    public class PerRequestModule : Autofac.Module
    {
        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var controllersAssembly = Assembly.GetAssembly(typeof(VehicleController));

            builder.RegisterApiControllers(controllersAssembly);
        }
    }
}
