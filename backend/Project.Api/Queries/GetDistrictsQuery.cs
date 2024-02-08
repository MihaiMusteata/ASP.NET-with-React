using MediatR;
using Project.Domain.Entities.Location;

namespace Project.Api.Queries
{
     public class GetDistrictsQuery : IRequest<List<DistrictData>>
     {
          public GetDistrictsQuery() { }
     }
}
