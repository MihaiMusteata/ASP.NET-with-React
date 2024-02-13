using MediatR;
using Project.Api.Queries;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.User;

namespace Project.Api.Handlers
{
     public class AddIBANHandler : IRequestHandler<AddIBANQuery, PostResponse>
     {
          private readonly IIBANManager _ibanManager;
          public AddIBANHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _ibanManager = bl.GetIBANManagerBL();
          }
          public async Task<PostResponse> Handle(AddIBANQuery request, CancellationToken cancellationToken)
          {
               IBANModel model = request.iban;
               IBANData IBAN = new IBANData
               {
                    Year = model.Year,
                    IBAN = model.IBAN,
                    District = model.District,
                    Region = model.Region,
                    EcoCode = model.EcoCode

               };
               return _ibanManager.AddIBAN(IBAN);
          }
     }
}
