using MediatR;
using Project.Domain.Entities.IBAN;

namespace Project.Api.Queries
{
     public class GetIBANsQuery : IRequest<List<IBANData>>
     {
          public GetIBANsQuery() { }
     }
}
