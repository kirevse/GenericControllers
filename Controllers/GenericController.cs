using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class GenericController<TEntity> : ControllerBase
{
    protected ILogger Logger { get; }

    public GenericController(ILoggerFactory loggerFactory)
    {
        Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(GetType());
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(GetType().Name);
    }
}