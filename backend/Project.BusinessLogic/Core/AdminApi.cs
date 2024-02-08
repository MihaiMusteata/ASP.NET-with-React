using Project.Api.Models;
using Project.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Core
{
     public class AdminApi
     {
          public List<UserMinimal> GetUsersList()
          {
               List<UserMinimal> users = new List<UserMinimal>();

               using (var db = new MinisterulFinantelorContext())
               {
                    var users_list = db.Users.ToList();

                    foreach (var u in users_list)
                    {
                         users.Add(new UserMinimal
                         {
                              Id = u.Id,
                              Username = u.Username,
                              Email = u.Email,
                              Gender = u.Gender,
                              Level = u.Level
                         });
                    }
               }
               return users;
          }
          public PostResponse DeleteUser(int id)
          {
               using (var db = new MinisterulFinantelorContext())
               {
                    var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                    if (user != null)
                    {
                         db.Users.Remove(user);
                         //check for cookies
                         var cookie = db.Sessions.Where(s => s.UserId == id).FirstOrDefault();
                         if (cookie != null)
                         {
                              db.Sessions.Remove(cookie);
                         }
                         db.SaveChanges();
                         return new PostResponse
                         {
                              Status = true,
                              StatusMsg = "User deleted successfully"
                         };
                    }
                    else
                    {
                         return new PostResponse
                         {
                              Status = false,
                              StatusMsg = "User not found"
                         };
                    }
               }
          }
     }
}
