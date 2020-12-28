using System;

namespace GenericControllers.Features
{
    public class GenericControllerConfiguration
    {
        public string Name { get; set; }
        public Type ControllerType { get; set; }
        public Type ModelType { get; set; }
    }
}
