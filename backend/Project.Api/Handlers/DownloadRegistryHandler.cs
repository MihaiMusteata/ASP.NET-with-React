using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.IBAN;

namespace Project.Api.Handlers
{
     public class DownloadRegistryHandler : IRequestHandler<DownloadRegistryQuery, RegistryData>
     {
          private readonly IIBANManager _ibanManager;
          public DownloadRegistryHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _ibanManager = bl.GetIBANManagerBL();
          }
          public async Task<RegistryData> Handle(DownloadRegistryQuery request, CancellationToken cancellationToken)
          {
               return _ibanManager.DownloadRegistryData(request.year);
          }
     }
}
