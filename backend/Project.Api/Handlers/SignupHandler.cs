using MediatR;
using Project.Api.Queries;
using Project.Domain.Entities.User;

namespace Project.Api.Handlers
{
     public class SignupHandler: IRequestHandler<SignupQuery, PostResponse>
     {
          private readonly BusinessLogic.Interfaces.ISession _session;
          public SignupHandler()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }
          public async Task<PostResponse> Handle(SignupQuery request, CancellationToken cancellationToken)
          {
               UserSignup model = request.model;
               HttpContext httpContext = request.httpContext;
               USignupData data = new USignupData
               {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Gender = model.Gender,
                    Distrcit = model.District,
                    Region = model.Region,
                    LoginIp = httpContext.Connection.RemoteIpAddress.ToString(),
                    LoginDateTime = model.LoginDateTime,
                    Level = model.Level

               };
               var userSignup = _session.UserSignup(data);
               return userSignup;
          }
     }
}
