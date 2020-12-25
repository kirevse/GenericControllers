using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    protected ICollection<Type> Types { get; }

    public GenericControllerFeatureProvider(ICollection<Type> types)
    {
        Types = types ?? throw new ArgumentNullException(nameof(types)); 
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