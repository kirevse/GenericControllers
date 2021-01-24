using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GenericControllers.Features
{
    internal class GenericControllersOptions : IGenericControllersOptions
    {
        public ISet<Type> ControllerTypes { get; } = new HashSet<Type>();

        public IGenericControllersOptions AddController<TController>()
            where TController : ControllerBase
        {
            var controllerType = typeof(TController);
            if (controllerType.IsGenericType && controllerType.GenericTypeArguments.Any())
            {
                ControllerTypes.Add(controllerType);
            }
            return this;
        }
    }
}
