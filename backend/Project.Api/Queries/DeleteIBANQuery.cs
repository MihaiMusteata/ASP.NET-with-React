using MediatR;
using Project.Domain.Entities.User;

namespace Project.Api.Queries
{
     public class DeleteIBANQuery : IRequest<PostResponse>
     {
          public int Id { get; set; }
          public DeleteIBANQuery(int id)
          {
               this.Id = id;
          }
     }
}
