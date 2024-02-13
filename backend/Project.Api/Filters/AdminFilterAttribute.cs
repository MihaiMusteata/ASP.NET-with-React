using Project.Domain.Entities.Enums;
using System.Diagnostics;
using System;
using Project.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Project.Api.Filters
{
     //TODO: Fix Admin filter
     public class AdminFilterAttribute : Attribute, IActionFilter
     {
          private readonly BusinessLogic.Interfaces.ISession _session;
          public AdminFilterAttribute()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }
          public void OnActionExecuted(ActionExecutedContext context)
          {
               Debug.WriteLine("OnActionExecuted");
          }

          public void OnActionExecuting(ActionExecutingContext context)
          {
               Debug.WriteLine("OnActionExecuting");
               var cookie = context.HttpContext.Request.Cookies["X-Key"];
               if (cookie != null)
               {
                    Debug.WriteLine("Cookie found : " + cookie);
                    var profile = _session.GetUserByCookie(cookie);
                    if (profile != null && profile.Level == URole.Admin)
                    {
                         Debug.WriteLine("Admin");
                    }
                    else
                    {
                         context.HttpContext.Response.StatusCode = 401;
                         Debug.WriteLine("Not Admin");
                    }
               }
               else
               {
                    Debug.WriteLine("Cookie not found");
               }
          }
     }
}
