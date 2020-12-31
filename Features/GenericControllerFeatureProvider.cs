using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace GenericControllers.Features
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        protected GenericControllersOptions GenericControllersOptions { get; }

        public GenericControllerFeatureProvider(GenericControllersOptions genericControllersOptions)
        {
            GenericControllersOptions =
                genericControllersOptions
                    ?? throw new ArgumentNullException(nameof(genericControllersOptions));
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> applicationParts, ControllerFeature controllerFeature)
        {
            var controllerTypeInfos = controllerFeature.Controllers;
            GenericControllersOptions.ControllerTypes
                .Where(t => t.IsGenericType &&
                    !controllerTypeInfos.Any(ti => $"{t.GenericTypeArguments.FirstOrDefault()?.Name}Controller".Equals(ti.Name)))
                .Aggregate(controllerTypeInfos, (cts, t) =>
                    {
                        cts.Add(t.GetTypeInfo());
                        return cts;
                    });
        }
    }
}
