using Microsoft.Extensions.DependencyInjection;
using GenericControllers.Conventions;
using GenericControllers.Features;

namespace GenericControllers.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, GenericControllersOptions genericControllersConfigurations) =>
            mvcBuilder
                .AddMvcOptions(moa => moa.Conventions.Add(new GenericControllerNameConvention()))
                .ConfigureApplicationPartManager(apm => apm.FeatureProviders
                    .Add(new GenericControllerFeatureProvider(genericControllersConfigurations)));
    }
}
