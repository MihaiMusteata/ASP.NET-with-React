using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities.Location
{
     public class RegionData
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public int DistrictId { get; set; }
     }
}
