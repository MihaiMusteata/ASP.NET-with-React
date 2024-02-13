using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
     public interface IIBANManager
     {
          List<IBANData> GetIBANs();
          PostResponse AddIBAN(IBANData iban);
          PostResponse DeleteIBAN(int id);
     }
}
