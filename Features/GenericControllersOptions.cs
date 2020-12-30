using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GenericControllers.Features
{
    public class GenericControllersOptions
    {
        public IList<Type> ControllerTypes { get; } = new List<Type>();

        public GenericControllersOptions AddController<TController>()
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
