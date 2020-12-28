using System;
using System.Collections.Generic;
using GenericControllers.Features;
using Microsoft.Extensions.DependencyInjection;

namespace GenericControllers.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, Action<ICollection<GenericControllerConfiguration>> genericControllerConfigurations = null) =>
            mvcBuilder
                .ConfigureApplicationPartManager(apm => apm.FeatureProviders
                    .Add(new GenericControllerFeatureProvider(genericControllerConfigurations)));
    }
}
