using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace GenericControllers.Features
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        protected ICollection<GenericControllerConfiguration> GenericControllerConfigurations{ get; }

        public GenericControllerFeatureProvider(Action<ICollection<GenericControllerConfiguration>> genericControllerConfigurations)
        {
            GenericControllerConfigurations =
                (genericControllerConfigurations
                    ?? throw new ArgumentNullException(nameof(genericControllerConfigurations))).Invoke();
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> applicationParts, ControllerFeature controllerFeature)
        {
            // This is designed to run after the default ControllerTypeProvider, 
            // so the list of 'real' controllers has already been populated.
            foreach (var entityType in Types)
            {
                var typeName = entityType.Name + "Controller";
                if (!controllerFeature.Controllers.Any(t => t.Name == typeName))
                {
                    // There's no 'real' controller for this entity, so add the generic version.
                    controllerFeature.Controllers
                        .Add(typeof(GenericController<>)
                            .MakeGenericType(entityType.AsType())
                            .GetTypeInfo());
                }
            }
        }
    }
}
