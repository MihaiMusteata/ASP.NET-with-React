using MediatR;
using Project.Domain.Entities.User;

namespace Project.Api.Queries
{
     public class SignupQuery: IRequest<PostResponse>
     {
          public UserSignup model { get; }
          public HttpContext httpContext { get; }
          public SignupQuery(UserSignup model, HttpContext httpContext)
          {
               this.model = model;
               this.httpContext = httpContext;
          }
     }
}
