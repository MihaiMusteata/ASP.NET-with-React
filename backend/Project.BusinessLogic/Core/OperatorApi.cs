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
               var validator = new IBANValidator();
               var result = validator.Validate(iban);

               if (!result.IsValid)
               {
                    string errors = "";
                    foreach (var failure in result.Errors)
                    {
                         errors += failure.ErrorMessage + "\n";
                    }
                    return new PostResponse
                    {
                         Status = false,
                         StatusMsg = errors
                    };
               }
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
               var validator = new IBANValidator();
               var result = validator.Validate(iban);

               if (!result.IsValid)
               {
                    string errors = "";
                    foreach (var failure in result.Errors)
                    {
                         errors += failure.ErrorMessage + "\n";
                    }
                    return new PostResponse
                    {
                         Status = false,
                         StatusMsg = errors
                    };
               }
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

          public RegistryData DownloadRegistry(int year)
          {
               using (var db = new MinisterulFinantelorContext())
               {
                    var ibans = db.IBans.Where(i => i.Year == year).ToList();
                    if (ibans.Count == 0)
                    {
                         return null; // Returnează null dacă nu sunt IBAN-uri disponibile pentru anul specificat
                    }

                    string fileName = "IBAN_Registry_" + year + ".csv";
                    string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;

                    using (MemoryStream memoryStream = new MemoryStream())
                    using (StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
                    {
                         streamWriter.WriteLine("Year,IBAN,EcoCode,District,Region");
                         foreach (var iban in ibans)
                         {
                              streamWriter.WriteLine($"{iban.Year},{iban.IBAN},{iban.EcoCode},{iban.District},{iban.Region}");
                         }
                         streamWriter.Flush();
                         memoryStream.Position = 0;

                         return new RegistryData
                         {
                              Content = memoryStream.ToArray(),
                              FileName = fileName,
                              ContentType = "text/csv"
                         };
                    }
               }
          }

     }
}
