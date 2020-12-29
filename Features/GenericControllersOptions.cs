using System;
using System.Collections.Generic;

namespace GenericControllers.Features
{
    public class GenericControllersOptions
    {
        public IList<GenericControllerConfiguration> GenericControllerConfigurations { get; } = new List<GenericControllerConfiguration>();

        public GenericControllersOptions AddGenericController(Type type, IList<Type> typeArguments)
        {
            GenericControllerConfigurations.Add(new GenericControllerConfiguration
            {
                ControllerType = type,
                TypeArguments = typeArguments
            });
            return this;
        }
    }
}
