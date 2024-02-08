using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;

namespace Project.Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class LocationController : ControllerBase
     {
          private readonly IMediator _mediator;
          public LocationController(IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpGet("districts")]
          public async Task<ActionResult> GetDistricts()
          {
               var query = new GetDistrictsQuery();
               var result = await _mediator.Send(query);
               if (result != null)
               {
                    return Ok(result);
               }
               else
               {
                    return BadRequest(result);
               }
          }

          [HttpGet("regions")]
          public async Task<ActionResult> GetRegions()
          {
               var query = new GetRegionsQuery();
               var result = await _mediator.Send(query);
               if (result != null)
               {
                    return Ok(result);
               }
               else
               {
                    return BadRequest(result);
               }
          }

     }
}
