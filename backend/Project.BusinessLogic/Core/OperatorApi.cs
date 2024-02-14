using Project.Api.Models;
using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Core
{
     public class OperatorApi
     {
          public List<IBANData> GetIBANsList()
          {
               List<IBANData> ibans = new List<IBANData>();
               using (var db = new MinisterulFinantelorContext())
               {
                    var ibans_list = db.IBans.ToList();
                    foreach (var iban in ibans_list)
                    {
                         ibans.Add(new IBANData
                         {
                              Id = iban.Id,
                              Year = iban.Year,
                              IBAN = iban.IBAN,
                              EcoCode = iban.EcoCode,
                              District = iban.District,
                              Region = iban.Region
                         });
                    }
               }
               return ibans;
          }

          public PostResponse DeleteIBANACtion(int id)
          {
               {
                    using (var db = new MinisterulFinantelorContext())
                    {
                         var iban = db.IBans.Where(i => i.Id == id).FirstOrDefault();
                         if (iban != null)
                         {
                              db.IBans.Remove(iban);
                              db.SaveChanges();
                              return new PostResponse
                              {
                                   Status = true,
                                   StatusMsg = "IBAN deleted successfully"
                              };
                         }
                         else
                         {
                              return new PostResponse
                              {
                                   Status = false,
                                   StatusMsg = "IBAN not found"
                              };
                         }
                    }
               }
          }

          public PostResponse AddIBANAction(IBANData iban)
          {
               using (var db = new MinisterulFinantelorContext())
               {
                    var iban_exists = db.IBans.Where(i => i.IBAN == iban.IBAN).FirstOrDefault();
                    if (iban_exists != null)
                    {
                         return new PostResponse
                         {
                              Status = false,
                              StatusMsg = "IBAN already exists"
                         };
                    }
                    else
                    {
                         db.IBans.Add(new IBanDbTable
                         {
                              Year = iban.Year,
                              IBAN = iban.IBAN,
                              EcoCode = iban.EcoCode,
                              District = iban.District,
                              Region = iban.Region
                         });
                         db.SaveChanges();
                         return new PostResponse
                         {
                              Status = true,
                              StatusMsg = "IBAN added successfully"
                         };
                    }
               }
          }

          public PostResponse UpdateIBANAction(IBANData iban)
          {
               using (var db = new MinisterulFinantelorContext())
               {
                    var iban_exists = db.IBans.Where(i => i.Id == iban.Id).FirstOrDefault();
                    if (iban_exists != null)
                    {
                         iban_exists.Year = iban.Year;
                         iban_exists.IBAN = iban.IBAN;
                         iban_exists.EcoCode = iban.EcoCode;
                         iban_exists.District = iban.District;
                         iban_exists.Region = iban.Region;
                         db.SaveChanges();
                         return new PostResponse
                         {
                              Status = true,
                              StatusMsg = "IBAN updated successfully"
                         };
                    }
                    else
                    {
                         return new PostResponse
                         {
                              Status = false,
                              StatusMsg = "IBAN not found"
                         };
                    }
               }
          }

     }
}
