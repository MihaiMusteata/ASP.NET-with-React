using MediatR;

namespace Project.Api.Queries
{
     public class GetWeatherForecastQuery: IRequest<string>
     {
          public int id { get; }
          public GetWeatherForecastQuery(int id)
          {
               this.id = id;
          }
     }
}
