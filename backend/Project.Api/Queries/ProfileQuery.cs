using MediatR;
using Project.Domain.Entities.User;

namespace Project.Api.Queries
{
     public class ProfileQuery: IRequest<UserMinimal>
     {
          public HttpContext httpContext { get; }
          public ProfileQuery(HttpContext httpContext)
          {
               this.httpContext = httpContext;
          }
     }
}
