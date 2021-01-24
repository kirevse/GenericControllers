using Microsoft.AspNetCore.Mvc;

namespace GenericControllers.Features
{
    public interface IGenericControllersOptions
    {
        IGenericControllersOptions AddController<TController>() where TController : ControllerBase;
    }
}
