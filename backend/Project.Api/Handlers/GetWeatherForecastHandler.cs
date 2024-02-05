using MediatR;
using Project.Api.Queries;
using Project.Api.Models;

namespace Project.Api.Handlers
{
     public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, string>
     {

          WeatherForecast weather = new WeatherForecast();
          public async Task<string> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
          {
               var id = request.id;
               if (id < 0 || id >= weather.weather.Length)
               {
                    return null;
               }
               return weather.weather[id];
          }
     }
}
