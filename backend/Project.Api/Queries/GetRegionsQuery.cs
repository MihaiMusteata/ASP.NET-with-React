using MediatR;
using Project.Domain.Entities.Location;

namespace Project.Api.Queries
{
     public class GetRegionsQuery : IRequest<List<RegionData>>
     {
          public GetRegionsQuery() { }
     }
}
