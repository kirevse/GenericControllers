using System;
using System.Collections.Generic;

namespace GenericControllers.Features
{
    public class GenericControllersOptions
    {
        public IList<GenericControllerConfiguration> GenericControllerConfigurations { get; } = new List<GenericControllerConfiguration>();

        public GenericControllersOptions AddGenericController(string name, Type type, IList<Type> typeArguments)
        {
            GenericControllerConfigurations.Add(new GenericControllerConfiguration
            {
                Name = name,
                ControllerType = type,
                TypeArguments = typeArguments
            });
            return this;
        }
    }
}
