using Microsoft.Extensions.DependencyInjection;
using GenericControllers.Conventions;
using GenericControllers.Features;
using System;

namespace GenericControllers.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, Action<IGenericControllersOptions> genericControllersOptionsAction) =>
            mvcBuilder
                .AddMvcOptions(moa => moa.Conventions.Add(new GenericControllerNameConvention()))
                .ConfigureApplicationPartManager(apm => apm.FeatureProviders
                    .Add(new GenericControllerFeatureProvider(genericControllersOptionsAction)));
    }
}
