using Project.Domain.Entities.User;
using MediatR;

namespace Project.Api.Queries
{
     public class GetUsersQuery: IRequest<List<UserMinimal>>
     {
          public GetUsersQuery() { }
     }
}
