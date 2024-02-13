﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Filters;
using Project.Api.Queries;
using System.Diagnostics;

namespace Project.Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class DashboardController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly HttpContext _httpContext;
          public DashboardController(IMediator mediator)
          {
               _mediator = mediator;
               _httpContext = HttpContext;

          }

          [HttpPost("user")]
          [AdminFilter]
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

          [HttpPost("iban")]
          public async Task<ActionResult> AddIBAN(IBANModel iban)
          {
               var query = new AddIBANQuery(iban);
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
          [AdminFilter]
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

          [HttpGet("ibans")]
          public async Task<ActionResult> GetIbans()
          {
               var query = new GetIBANsQuery();
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

          [HttpGet("region_ibans")]
          public async Task<ActionResult> GetRegionIbans(string region)
          {
               var query = new GetRegionIBANsQuery(region);
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
          [AdminFilter]
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

          [HttpDelete("iban")]
          public async Task<ActionResult> DeleteIBAN(int ibanId)
          {
               var query = new DeleteIBANQuery(ibanId);
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

     }
}
