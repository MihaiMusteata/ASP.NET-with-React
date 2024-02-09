using MediatR;
using Project.Domain.Entities.User;

namespace Project.Api.Queries
{
     public class DeleteUserQuery : IRequest<PostResponse>
     {
          public int UserId { get; }
          public DeleteUserQuery(int userId)
          {
               UserId = userId;
          }
     }
}
