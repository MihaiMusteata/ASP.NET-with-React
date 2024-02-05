using MediatR;
using Project.Api.Queries;
using Project.Domain.Entities.User;
using Project.BusinessLogic.Interfaces;
using System.Diagnostics;

namespace Project.Api.Handlers
{
     public class LoginHandler : IRequestHandler<LoginQuery, PostResponse>
     {
          private readonly BusinessLogic.Interfaces.ISession _session;
          public LoginHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }

          public async Task<PostResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
          {
               UserLogin model = request.model;
               HttpContext httpContext = request.httpContext;
               ULoginData data = new ULoginData
               {
                    Credential = model.Credential,
                    Password = model.Password
               };
               var userLogin = _session.UserLogin(data);

               if (userLogin.Status)
               {
                    var cookieData = _session.GenCookie(data.Credential);
                    httpContext.Response.Cookies.Append(cookieData.Key, cookieData.Value, cookieData.Options);
               }

               return userLogin;
          }

     }
}
