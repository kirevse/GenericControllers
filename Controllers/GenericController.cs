using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class GenericController<TModel> : ControllerBase where TModel : new()
{
    protected ILogger Logger { get; }

    public GenericController(ILoggerFactory loggerFactory) =>
        Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(GetType());

    [HttpGet]
    public IActionResult Get()
    {
        Logger.LogInformation("Processing GET");
        return Ok(new TModel());
    }
}