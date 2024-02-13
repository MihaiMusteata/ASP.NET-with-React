using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.User;

namespace Project.Api.Handlers
{
     public class DeleteIBANHandler : IRequestHandler<DeleteIBANQuery, PostResponse>
     {
          private readonly IIBANManager _ibanManager;
          public DeleteIBANHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _ibanManager = bl.GetIBANManagerBL();
          }
          public async Task<PostResponse> Handle(DeleteIBANQuery request, CancellationToken cancellationToken)
          {
               return _ibanManager.DeleteIBAN(request.Id);
          }
     }
}
