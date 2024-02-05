using MediatR;
using Project.Api.Queries;

namespace Project.Api.Handlers
{
     public class LogoutHandler : IRequestHandler<LogoutQuery, Unit>
     {
          private readonly BusinessLogic.Interfaces.ISession _session;
          public LogoutHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }
          public async Task<Unit> Handle(LogoutQuery request, CancellationToken cancellationToken)
          {
               int userId = request.userId;
               // TODO - Fix logic to delete the cookie
               //HttpContext httpContext = request.httpContext;
               //httpContext.Response.Cookies.Delete("X-Key");
               _session.UserLogout(userId);
               return Unit.Value;
          }
     }
}
