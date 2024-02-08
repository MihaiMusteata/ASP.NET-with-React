using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.Location;

namespace Project.Api.Handlers
{
     public class GetDistrictsHandler : IRequestHandler<GetDistrictsQuery, List<DistrictData>>
     {
          private readonly ILocationManager _locationManager;
          public GetDistrictsHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _locationManager = bl.GetLocationManagerBL();
          }
          public async Task<List<DistrictData>> Handle(GetDistrictsQuery request, CancellationToken cancellationToken)
          {
               return _locationManager.GetDistricts();
          }
     }
}
