using Project.Domain.Entities.User;
using MediatR;

namespace Project.Api.Queries
{
     public class LoginQuery: IRequest<PostResponse>
     {
          public UserLogin model { get; }
          public HttpContext httpContext { get; }
          public LoginQuery(UserLogin model, HttpContext httpContext)
          {
               this.model = model;
               this.httpContext = httpContext;
          }
     }
}
