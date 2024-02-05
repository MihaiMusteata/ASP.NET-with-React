using MediatR;

namespace Project.Api.Queries
{
     public class LogoutQuery : IRequest<Unit>
     {
          public int userId { get; }
          public HttpContext httpContext { get; }
          public LogoutQuery(HttpContext httpContext, int userId)
          {
               this.userId = userId;
               this.httpContext = httpContext;
          }
     }
}
