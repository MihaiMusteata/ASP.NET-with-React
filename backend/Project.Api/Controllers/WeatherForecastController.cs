using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Filters;
using Project.Api.Queries;
using System.Diagnostics;

namespace Project.Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class WeatherForecastController : ControllerBase
     {
          private readonly IMediator _mediator;
          public WeatherForecastController(IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpGet]
          [AdminFilter]
          public async Task<ActionResult> GetWeatherForecast(int id)
          {
               var query = new GetWeatherForecastQuery(id);
               var result = await _mediator.Send(query);
               if (result == null)
               {
                    return NotFound();
               }
               return Ok(result);
          }

          [HttpGet("extract")]
          public async Task<ActionResult> Extract()
          {
               var cookie = HttpContext.Request.Cookies["X-Key"];
               Debug.WriteLine("Cookie found : " + cookie);
               return Ok();
          }

     }
}