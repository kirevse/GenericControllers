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
        protected GenericControllersOptions GenericControllersOptions{ get; }

        public GenericControllerFeatureProvider(GenericControllersOptions genericControllersOptions)
        {
            GenericControllersOptions =
                genericControllersOptions
                    ?? throw new ArgumentNullException(nameof(genericControllersOptions));
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> applicationParts, ControllerFeature controllerFeature)
        {
            // This is designed to run after the default ControllerTypeProvider, 
            // so the list of 'real' controllers has already been populated.
            var controllerTypeInfos = controllerFeature.Controllers;
            GenericControllersOptions.GenericControllerConfigurations
                .Where(gcc => !controllerTypeInfos.Any(t => t.Name == gcc.Name))
                .Aggregate(controllerTypeInfos, (cts, gcc) => 
                    {
                        cts.Add(
                            gcc.ControllerType
                           .MakeGenericType(gcc.TypeArguments.ToArray())
                           .GetTypeInfo());
                        return cts;
                    });
        }
    }
}
