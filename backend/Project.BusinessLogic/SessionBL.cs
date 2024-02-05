using Project.BusinessLogic.Core;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.Session;
using Project.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public PostResponse UserSignup(USignupData data)
          {
               return UserSignupAction(data);
          }

          public PostResponse UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }

          public PostResponse UserLogout(int userId)
          {
               return UserLogoutAction(userId);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return GetUserDataByCookie(apiCookieValue);
          }

          public CookieData GenCookie(string loginCredential)
          {
               return UserGenCookies(loginCredential);
          }
     }
}
