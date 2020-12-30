using Microsoft.Extensions.DependencyInjection;
using GenericControllers.Features;

namespace GenericControllers.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, GenericControllersOptions genericControllersConfigurations) =>
            mvcBuilder
                .ConfigureApplicationPartManager(apm => apm.FeatureProviders
                    .Add(new GenericControllerFeatureProvider(genericControllersConfigurations)));
    }
}
