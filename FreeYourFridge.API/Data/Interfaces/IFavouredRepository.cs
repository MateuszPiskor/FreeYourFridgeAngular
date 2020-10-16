using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using FreeYourFridge.API.Helpers;


namespace FreeYourFridge.API.Data
{
    public interface IFavouredRepository: IGenericRepository
    {
        Task<Favoured> AddFavoured(Favoured favoured);
        Task<PagedList<Favoured>> GetFavoureds(UserParams userParams);
        void DeleteFavoured(int id,int userId);
        Task UpdateFavaoured(int id, int score, int userId);
        Task<bool> FavouredExist(int id);
        Task<Favoured> GetFavoured(int id, int userId);
    }
}