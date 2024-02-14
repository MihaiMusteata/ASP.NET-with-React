using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.User;

namespace Project.Api.Handlers
{
     public class UpdateIBANHandler : IRequestHandler<UpdateIBANQuery, PostResponse>
     {
          private readonly IIBANManager _ibanManager;
          public UpdateIBANHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _ibanManager = bl.GetIBANManagerBL();
          }
          public async Task<PostResponse> Handle(UpdateIBANQuery request, CancellationToken cancellationToken)
          {
               IBANData iban_data= new IBANData
               {
                    IBAN = request.iban.IBAN,
                    District = request.iban.District,
                    EcoCode = request.iban.EcoCode,
                    Id = request.iban.Id,
                    Year = request.iban.Year,
                    Region = request.iban.Region
               };
               return _ibanManager.UpdateIBAN(iban_data);
          }
     }
}
