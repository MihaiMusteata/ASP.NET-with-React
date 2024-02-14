using MediatR;
using Project.Domain.Entities.User;

namespace Project.Api.Queries
{
     public class UpdateUserQuery : IRequest<PostResponse>
     {
          public UserMinimal user { get; set; }
          public UpdateUserQuery(UserMinimal user)
          {
               this.user = user;
          }
     }
}
