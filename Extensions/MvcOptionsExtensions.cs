using System;
using System.Collections.Generic;
using GenericControllers.Features;
using GenericControllers.Conventions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GenericControllers.Extensions
{
    public static class MvcOptionsExtensions
    {
        public static MvcOptions AddGenericControllerNameConvention(this MvcOptions mvcOptions)
        {
            mvcOptions.Conventions.Add(new GenericControllerNameConvention());
            return mvcOptions;
        }
    }
}