using Project.Api.Queries;
using Project.Domain.Entities.User;
using MediatR;

namespace Project.Api.Handlers
{
     public class ProfileHandler : IRequestHandler<ProfileQuery, UserMinimal>
     {
          private readonly BusinessLogic.Interfaces.ISession _session;
          public ProfileHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }
          public async Task<UserMinimal> Handle(ProfileQuery request, CancellationToken cancellationToken)
          {
               HttpContext httpContext = request.httpContext;
               var cookie = httpContext.Request.Cookies["X-Key"];
               if (cookie != null)
               {
                    var profile = _session.GetUserByCookie(cookie);
                    if (profile != null)
                    {
                         return profile;
                    }
                    else
                    {
                         // TODO : No profile found
                         return null;
                    }
               }
               else
               {
                    // TODO : No cookie found
                    return null;
               }
          }
     }
}
