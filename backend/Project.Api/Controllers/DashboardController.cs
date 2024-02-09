using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Queries;
using System.Diagnostics;

namespace Project.Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class DashboardController : ControllerBase
     {
          private readonly IMediator _mediator;
          public DashboardController(IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpPost("user")]
          public async Task<ActionResult> AddUser(UserSignup user)
          {
               var query = new SignupQuery(user, HttpContext);
               var result = await _mediator.Send(query);

               if (result.Status)
               {
                    return Ok(result);
               }
               else
               {
                    return BadRequest(result);
               }
          }

          [HttpGet("users")]
          public async Task<ActionResult> GetUsers()
          {
               var query = new GetUsersQuery();
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

          [HttpDelete("user")]
          public async Task<ActionResult> DeleteUser(int userId)
          {
               var query = new DeleteUserQuery(userId);
               var result = await _mediator.Send(query);
               Debug.WriteLine(result.StatusMsg);
               if (result.Status)
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
