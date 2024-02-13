using MediatR;
using Project.Domain.Entities.User;

namespace Project.Api.Queries
{
     public class AddIBANQuery : IRequest<PostResponse>
     {
          public IBANModel iban { get; set; }
          public AddIBANQuery(IBANModel iban)
          {
               this.iban = iban;
          }
     }
}
