using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.BusinessLogic.Core;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.Location;

namespace Project.BusinessLogic
{
     public class LocationManagerBL: UserApi, ILocationManager
     {
          public List<DistrictData> GetDistricts()
          {
               return GetDistrictsList();
          }
          public List<RegionData> GetRegions()
          {
               return GetRegionsList();
          }
     }
}
