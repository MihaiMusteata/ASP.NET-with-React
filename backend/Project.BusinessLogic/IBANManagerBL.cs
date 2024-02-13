using Project.BusinessLogic.Core;
using Project.BusinessLogic.Interfaces;
using Project.Domain.Entities.IBAN;
using Project.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
     public class IBANManagerBL : OperatorApi, IIBANManager
     {
          public List<IBANData> GetIBANs()
          {
               return GetIBANsList();
          }

          public PostResponse DeleteIBAN(int id)
          {
               return DeleteIBANACtion(id);
          }

          public PostResponse AddIBAN(IBANData iban)
          {
               return AddIBANAction(iban);
          }
     }
}
