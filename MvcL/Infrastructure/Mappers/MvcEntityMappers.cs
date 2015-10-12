using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using MvcL.Models;
using System.IO;

namespace MvcL.Infrastructure.Mappers
{
    public static class MvcEntityMappers
    {

        //Movie
        public static MovieViewModel ToMvcModel(this MovieEntity entity)
        {
            return new MovieViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Length = entity.Length,
                Mark = entity.Mark,
                Producer = entity.Producer,
                Budget = entity.Budget,
                PistureString = "data:image/jpeg;base64," + Convert.ToBase64String(entity.Picture)
            };
        }

        public static MovieEntity ToBllEntity(this MovieViewModel model)
        {
            var result = new MovieEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Year = model.Year,
                Length = model.Length,
                Mark = model.Mark,
                Producer = model.Producer,
                Budget = model.Budget
            };
            if (model.Picture != null)
            {
                byte[] input = null;
                var br = new BinaryReader(model.Picture.InputStream);
                input = br.ReadBytes((int)model.Picture.ContentLength);
                result.Picture = new byte[input.Length];
                input.CopyTo(result.Picture, 0);
            }
            else
                result.Picture = null;
            return result;
        }

        //User
        public static UserViewModel ToMvcModel(this UserEntity entity)
        {
            return new UserViewModel()
            {
                Id = entity.Id,
                Login = entity.Login,
                Name = entity.Name,
                Password = entity.Password,
                RoleId = entity.RoleId
            };
        }

        public static UserEntity ToBllEntity(this UserViewModel model)
        {
            return new UserEntity()
            {
                Id = model.Id,
                Login = model.Login,
                Name = model.Name,
                Password = model.Password,
                RoleId = model.RoleId
            };
        }
    }
}