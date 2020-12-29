using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace GenericControllers.Conventions
{
    public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controllerModel)
        {
            var controllerType = controllerModel.ControllerType;
            if (controllerType.IsGenericType && controllerType.GetGenericTypeDefinition() == typeof(GenericController<>))
            {
                controllerModel.ControllerName = controllerType.GenericTypeArguments.FirstOrDefault()?.Name;
            }
        }
    }
}