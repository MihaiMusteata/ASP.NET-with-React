using MediatR;
using Project.Domain.Entities.IBAN;

namespace Project.Api.Queries
{
     public class GetRegionIBANsQuery : IRequest<List<IBANData>>
     {
          public string region;
          public GetRegionIBANsQuery(string region)
          {
               this.region = region;
          }
     }
}
