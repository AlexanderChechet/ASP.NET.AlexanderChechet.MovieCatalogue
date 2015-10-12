using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IUnitOfWork unitOfWork;

        public FavoriteService(IFavoriteRepository fr, IUnitOfWork uow)
        {
            favoriteRepository = fr;
            unitOfWork = uow;
        }

        public FavoriteEntity GetById(int id)
        {
            return favoriteRepository.GetById(id).ToBllFavorite();
        }

        public FavoriteEntity GetFavorites(int id)
        {
            return favoriteRepository.GetFavorites(id).ToBllFavorite();
        }

        public IEnumerable<FavoriteEntity> GetAll()
        {
            return favoriteRepository.GetAll().Select(x => x.ToBllFavorite());
        }

        public void AddFavorite(FavoriteEntity favorite)
        {
            favoriteRepository.Create(favorite.ToDalFavorite());
        }

        public void DeleteFavorite(FavoriteEntity favorite)
        {
            favoriteRepository.Delete(favorite.ToDalFavorite());
        }
    }
}
