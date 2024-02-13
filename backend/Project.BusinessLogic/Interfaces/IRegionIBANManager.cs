using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
     public interface IRegionIBANManager
     {
          List<IBANData> GetRegionIBANs(string region);
     }
}
