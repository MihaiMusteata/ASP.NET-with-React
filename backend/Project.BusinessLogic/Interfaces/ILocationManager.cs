using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities.Location;


namespace Project.BusinessLogic.Interfaces
{
     public interface ILocationManager
     {
          List<DistrictData> GetDistricts();
          List<RegionData> GetRegions();
     }
}
