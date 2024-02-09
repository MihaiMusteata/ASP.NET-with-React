using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.User;

namespace Project.Api.Handlers
{
     public class DeleteUserHandler : IRequestHandler<DeleteUserQuery, PostResponse>
     {
          private readonly IUsersManager _usersManager;
          public DeleteUserHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _usersManager = bl.GetUsersManagerBL();
          }
          public async Task<PostResponse> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
          {
               return _usersManager.DeleteUser(request.UserId);
          }
     }
}
