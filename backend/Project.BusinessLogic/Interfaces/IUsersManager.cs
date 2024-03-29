﻿using Project.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
     public interface IUsersManager
     {
          List<UserMinimal> GetUsers();
          PostResponse DeleteUser(int id);
          PostResponse UpdateUser(UserMinimal user);
     }
}
