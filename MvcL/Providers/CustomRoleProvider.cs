using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Web.WebPages;
using Microsoft.Internal.Web.Utils;
using System.Web.Mvc;
using MvcL.Models;
using BLL.Services;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using Ninject;

namespace MvcL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IRoleService roleService;

        public override string[] GetRolesForUser(string login)
        {
            roleService = System.Web.Mvc.DependencyResolver.Current.GetService<IRoleService>();
            var userService = System.Web.Mvc.DependencyResolver.Current.GetService<IUserService>();
            string[] result = new string[] { };
            var user = userService.GetAllUsers().Where(x => x.Login == login).FirstOrDefault();
            if (user != null)
            {
                var role = roleService.GetUserRole(user);

                if (role != null)
                {
                    result = new string[] { role.RoleName };
                }
            }
            return result;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            roleService = System.Web.Mvc.DependencyResolver.Current.GetService<IRoleService>();
            bool outputResult = false;
            var role = roleService.GetUserRole(new UserEntity()
            {
                Login = username
            });
            outputResult = role.RoleName == roleName;
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}