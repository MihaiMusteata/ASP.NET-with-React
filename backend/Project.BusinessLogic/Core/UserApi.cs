using Project.Api.Models;
using Project.Domain.Entities.User;
using Project.Helpers;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Project.Domain.Entities.Session;
using Microsoft.AspNetCore.Http;
using Project.Domain.Entities.Location;

namespace Project.BusinessLogic.Core
{
     public class UserApi
     {
          internal PostResponse UserLoginAction(ULoginData data)
          {
               UDbTable result;
               var validate = new EmailAddressAttribute();
               var hash_password = LoginHelper.HashGen(data.Password);
               if (validate.IsValid(data.Credential))
               {
                    using (var db = new MinisterulFinantelorContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == hash_password);
                    }
                    if (result == null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "The username or Password is Incorrect" };
                    }
                    using (var todo = new MinisterulFinantelorContext())
                    {
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }
                    return new PostResponse { Status = true };
               }
               else
               {
                    using (var db = new MinisterulFinantelorContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == hash_password);
                    }
                    if (result == null)
                    {
                         return new PostResponse { Status = false, StatusMsg = "The username or Password is Incorrect" };
                    }
                    using (var todo = new MinisterulFinantelorContext())
                    {
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }

                    return new PostResponse { Status = true };
               }
          }

          internal PostResponse UserSignupAction(USignupData data)
          {
               UDbTable result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Email))
               {
                    var hash_password = LoginHelper.HashGen(data.Password);
                    result = new UDbTable
                    {
                         Username = data.Username,
                         Email = data.Email,
                         Password = hash_password,
                         Gender = data.Gender,
                         District = data.District,
                         Region = data.Region,
                         LastIp = data.LoginIp,
                         LastLogin = data.LoginDateTime,
                         Level = data.Level
                    };
                    using (var db = new MinisterulFinantelorContext())
                    {
                         db.Users.Add(result);
                         db.SaveChanges();
                    }
                    return new PostResponse { Status = true };
               }
               else
               {
                    return new PostResponse { Status = false, StatusMsg = "Invalid email" };
               }
          }

          internal PostResponse UserLogoutAction(int userId)
          {
               using var db = new MinisterulFinantelorContext();
               var record = db.Sessions.FirstOrDefault(s => s.UserId == userId);
               if (record != null)
               {
                    db.Sessions.Remove(record);
                    db.SaveChanges();
                    return new PostResponse { Status = true };
               }
               else
               {
                    return new PostResponse { Status = false, StatusMsg = "Couldn't delete, no such id" };
               }
          }

          internal CookieData UserGenCookies(string loginCredential)
          {
               var value = CookieGenerator.Create(loginCredential);

               var cookieOptions = new CookieOptions
               {
                    Domain = null,
                    //HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(1),
               };

               var cookie = new CookieData
               {
                    Key = "X-Key",
                    Value = value,
                    Options = cookieOptions
               };

               UDbTable result;

               using (var db = new MinisterulFinantelorContext())
               {
                    result = db.Users.FirstOrDefault(u => u.Email == loginCredential || u.Username == loginCredential);
               }

               loginCredential = result.Email;

               using (var db = new MinisterulFinantelorContext())
               {
                    SessionsDbTable current = db.Sessions.FirstOrDefault(s => s.UserId == result.Id);
                    if (current != null)
                    {
                         current.Cookie = cookie.Value;
                         current.ExpirationDate = DateTime.Now.AddDays(1);
                         using (var up = new MinisterulFinantelorContext())
                         {
                              db.Entry(current).State = EntityState.Modified;
                              db.SaveChanges();
                         }

                    }
                    else
                    {
                         var session = new SessionsDbTable();
                         session.Cookie = cookie.Value;
                         session.ExpirationDate = DateTime.Now.AddDays(1);
                         session.UserId = result.Id;
                         db.Sessions.Add(session);
                         db.SaveChanges();
                    }
               }
               Debug.WriteLine("Cookie Set:" + cookie.Value);
               return cookie;
          }

          internal UserMinimal GetUserDataByCookie(string cookie)
          {
               SessionsDbTable cData;
               using (var db = new MinisterulFinantelorContext())
               {
                    cData = db.Sessions.FirstOrDefault(s => s.Cookie == cookie);
                    if (cData == null)
                    {
                         return null;
                    }

               }

               UDbTable uData;
               using (var db = new MinisterulFinantelorContext())
               {
                    uData = db.Users.FirstOrDefault(u => u.Id == cData.UserId);
                    if (uData == null)
                    {
                         return null;
                    }
               }

               return new UserMinimal
               {
                    Id = uData.Id,
                    Username = uData.Username,
                    Email = uData.Email,
                    District = uData.District,
                    Region = uData.Region,
                    Level = uData.Level
               };
          }

          internal List<DistrictData> GetDistrictsList()
          {
               List<DistrictData> result = new List<DistrictData>();
               using (var db = new MinisterulFinantelorContext())
               {
                    var districts = db.Districts.ToList();

                    foreach (var item in districts)
                    {
                         result.Add(new DistrictData
                         {
                              Id = item.Id,
                              Name = item.Name
                         });
                    }
               }
               return result;
          }

          internal List<RegionData> GetRegionsList()
          {
               List<RegionData> result = new List<RegionData>();
               using (var db = new MinisterulFinantelorContext())
               {
                    var regions = db.Regions.ToList();

                    foreach (var item in regions)
                    {
                         result.Add(new RegionData
                         {
                              Id = item.Id,
                              Name = item.Name,
                              DistrictId = item.DistrictId
                         });
                    }
               }
               return result;
          }

     }

}
