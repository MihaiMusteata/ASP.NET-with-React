using MediatR;
using Project.Domain.Entities.IBAN;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;


namespace Project.Api.Handlers
{
     public class GetIBANsHandler : IRequestHandler<GetIBANsQuery, List<IBANData>>
     {
          private readonly IIBANManager _ibanManager;
          public GetIBANsHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _ibanManager = bl.GetIBANManagerBL();
          }
          public async Task<List<IBANData>> Handle(GetIBANsQuery request, CancellationToken cancellationToken)
          {
               return _ibanManager.GetIBANs();
          }
     }
}
