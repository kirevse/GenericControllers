using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GenericControllers.Conventions
{
    public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controllerModel)
        {
            var controllerType = controllerModel.ControllerType;
            if (controllerType.IsGenericType)
            {
                controllerModel.ControllerName = controllerType.GenericTypeArguments.FirstOrDefault()?.Name;
            }
        }
    }
}