using System;
using System.Collections.Generic;

namespace GenericControllers.Features
{
    public class GenericControllerConfiguration
    {
        public string Name { get; set; }
        public Type ControllerType { get; set; }
        public IList<Type> TypeArguments { get; set; }
    }
}
