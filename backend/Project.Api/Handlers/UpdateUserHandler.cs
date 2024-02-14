using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.User;

namespace Project.Api.Handlers
{
     public class UpdateUserHandler : IRequestHandler<UpdateUserQuery, PostResponse>
     {
          private readonly IUsersManager _usersManager;
          public UpdateUserHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _usersManager = bl.GetUsersManagerBL();
          }
          public async Task<PostResponse> Handle(UpdateUserQuery request, CancellationToken cancellationToken)
          {
               return _usersManager.UpdateUser(request.user);
          }

     }
}
