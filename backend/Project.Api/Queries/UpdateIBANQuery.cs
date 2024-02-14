using MediatR;
using Project.Domain.Entities.User;

namespace Project.Api.Queries
{
     public class UpdateIBANQuery : IRequest<PostResponse>
     {
          public IBANModel iban { get; set; }
          public UpdateIBANQuery(IBANModel iban)
          {
               this.iban = iban;
          }
     }
}
