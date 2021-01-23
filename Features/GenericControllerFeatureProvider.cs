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
        protected Action<GenericControllersOptions> GenericControllersOptionsAction { get; }

        public GenericControllerFeatureProvider(Action<GenericControllersOptions> genericControllersOptionsAction)
        {
            GenericControllersOptionsAction =
                genericControllersOptionsAction
                    ?? throw new ArgumentNullException(nameof(genericControllersOptionsAction));
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> applicationParts, ControllerFeature controllerFeature)
        {
            var controllerTypeInfos = controllerFeature.Controllers;
            var genericControllersOptions = new GenericControllersOptions();
            GenericControllersOptionsAction.Invoke(genericControllersOptions);
            genericControllersOptions.ControllerTypes
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
