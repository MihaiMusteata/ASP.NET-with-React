using Project.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
     public class BusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
          public IUsersManager GetUsersManagerBL()
          {
               return new UsersManagerBL();
          }
          public ILocationManager GetLocationManagerBL()
          {
               return new LocationManagerBL();
          }
          public IIBANManager GetIBANManagerBL()
          {
               return new IBANManagerBL();
          }
          public IRegionIBANManager GetRegionIBANManagerBL()
          {
               return new RegionIBANManagerBL();
          }
     }
}
