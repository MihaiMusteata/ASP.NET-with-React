using Project.BusinessLogic.Core;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
     public class UsersManagerBL: AdminApi, IUsersManager
     {
          public List<UserMinimal> GetUsers()
          {
               return GetUsersList();
          }
          public PostResponse DeleteUser(int id)
          {
               return DeleteUserAction(id);
          }
     }
}
