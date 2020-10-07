using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IFavouredRepository: IGenericRepository
    {
        Task<Favoured> AddFavoured(Favoured favoured);
        Task<IEnumerable<Favoured>> GetFavoureds();
        //Task<string> GetRecipesByIds(string idsString);
        void DeleteFavoured(int id,int userId);
        Task UpdateFavaoured(int id, int score, int userId);
        Task<bool> FavouredExist(int id);
    }
}