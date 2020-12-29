using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace GenericControllers.Conventions
{
    public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controllerModel)
        {
            if (controllerModel.ControllerType.GetGenericTypeDefinition() == typeof(GenericController<>))
            {
                controllerModel.ControllerName = controllerModel.ControllerType.GenericTypeArguments[0]?.Name;
            }
        }
    }
}