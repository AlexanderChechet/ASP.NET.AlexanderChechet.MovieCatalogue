using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {

        //Movie
        public static MovieEntity ToBllMovie(this DalMovie dalMovie)
        {
            return new MovieEntity()
            {
                Id = dalMovie.Id,
                Title = dalMovie.Title,
                Description = dalMovie.Description,
                Year = dalMovie.Year,
                Length = dalMovie.Length,
                Mark = dalMovie.Mark,
                Producer = dalMovie.Producer,
                Budget = dalMovie.Budget,
                Picture = dalMovie.Picture,
                Data = dalMovie.Data
            };
        }

        public static DalMovie ToDalMovie(this MovieEntity movieEntity)
        {
            return new DalMovie()
            {
                Id = movieEntity.Id,
                Title = movieEntity.Title,
                Description = movieEntity.Description,
                Year = movieEntity.Year,
                Length = movieEntity.Length,
                Mark = movieEntity.Mark,
                Producer = movieEntity.Producer,
                Budget = movieEntity.Budget,
                Picture = movieEntity.Picture,
                Data = movieEntity.Data
            };
        }

        //User
        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                Name = dalUser.Name,
                Password = dalUser.Password,
                RoleId = dalUser.RoleId
            };
        }

        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Name = userEntity.Name,
                Password = userEntity.Password,
                RoleId = userEntity.RoleId
            };
        }

        //Role
        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                RoleName = dalRole.RoleName
            };
        }

        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            return new DalRole() 
            {
                Id = roleEntity.Id,
                RoleName = roleEntity.RoleName
            };
        }

        //Mark
        public static MarkEntity ToBllMark(this DalMark dalMark)
        {
            return new MarkEntity()
            {
                Id = dalMark.Id,
                MovieId = dalMark.MovieId,
                UserId = dalMark.UserId,
                Mark = dalMark.Mark,
                Marks = dalMark.Marks,
                Target = dalMark.Target
            };
        }

        public static DalMark ToDalMark(this MarkEntity markEntity)
        {
            return new DalMark()
            {
                Id = markEntity.Id,
                MovieId = markEntity.MovieId,
                UserId = markEntity.UserId,
                Mark = markEntity.Mark,
                Marks = markEntity.Marks,
                Target = markEntity.Target
            };
        }

        //Favorite
        public static FavoriteEntity ToBllFavorite(this DalFavorite dalFavorite)
        {
            return new FavoriteEntity()
            {
                Id = dalFavorite.Id,
                UserId = dalFavorite.UserId,
                MovieId = dalFavorite.MovieId,
                Target = dalFavorite.Target,
                Movies = dalFavorite.Movies
            };
        }

        public static DalFavorite ToDalFavorite(this FavoriteEntity favoriteEntity)
        {
            return new DalFavorite()
            {
                Id = favoriteEntity.Id,
                UserId = favoriteEntity.UserId,
                MovieId = favoriteEntity.MovieId,
                Target = favoriteEntity.Target,
                Movies = favoriteEntity.Movies
            };
        }
    }
}
