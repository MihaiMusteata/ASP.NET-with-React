using MediatR;
using Project.Domain.Entities.IBAN;

namespace Project.Api.Queries
{
     public class DownloadRegistryQuery : IRequest<RegistryData>
     {
          public int year;
          public DownloadRegistryQuery(int year)
          {
               this.year = year;
          }
     }
}
