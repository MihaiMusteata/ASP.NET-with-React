using Project.Api.Models;
using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Core
{
     public class OperatorRaionApi
     {
          public List<IBANData> GetRegionIBANsList(string region)
          {
               List<IBANData> ibans = new List<IBANData>();
               using (var db = new MinisterulFinantelorContext())
               {
                    var ibans_list = db.IBans.Where(x => x.Region == region).ToList();
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
     }
}
