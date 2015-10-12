﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        RoleEntity GetUserRole(UserEntity user);
        IEnumerable<RoleEntity> GetAllRoles();
    }
}
