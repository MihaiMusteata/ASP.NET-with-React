using Project.BusinessLogic.Core;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
     public class RegionIBANManagerBL : OperatorRaionApi, IRegionIBANManager
     {
          public List<IBANData> GetRegionIBANs(string region)
          {
               return GetRegionIBANsList(region);
          }
     }
}
