using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.Location;

namespace Project.Api.Handlers
{
     public class GetRegionsHandler : IRequestHandler<GetRegionsQuery, List<RegionData>>
     {
          private readonly ILocationManager _locationManager;
          public GetRegionsHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _locationManager = bl.GetLocationManagerBL();
          }
          public async Task<List<RegionData>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
          {
               return _locationManager.GetRegions();
          }

     }
}
