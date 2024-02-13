using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.IBAN;

namespace Project.Api.Handlers
{
     public class GetRegionIBANsHandler : IRequestHandler<GetRegionIBANsQuery, List<IBANData>>
     {
          private readonly IRegionIBANManager _regionIBANManager;
          public GetRegionIBANsHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _regionIBANManager = bl.GetRegionIBANManagerBL();
          }
          public async Task<List<IBANData>> Handle(GetRegionIBANsQuery request, CancellationToken cancellationToken)
          {
               return _regionIBANManager.GetRegionIBANs(request.region);
          }
     }
}
