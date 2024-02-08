using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.User;

namespace Project.Api.Handlers
{
     public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserMinimal>>
     {
          private readonly IUsersManager _usersManager;
          public GetUsersHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _usersManager = bl.GetUsersManagerBL();
          }
          public async Task<List<UserMinimal>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
          {
               return _usersManager.GetUsers();
          }
     }
}
