using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;
using FreeYourFridge.API.Helpers;


namespace FreeYourFridge.API.Data
{
    public interface IFavouredRepository: IGenericRepository
    {
        Task<Favoured> AddFavoured(Favoured favoured);
        //Task<IEnumerable<Favoured>> GetFavoureds();
        Task<PagedList<Favoured>> GetFavoureds(UserParams userParams);

        Task<string> GetRecipesByIds(string idsString);
        void Delete(int id,int userId);
        Task UpdateFavaoured(int id, int score, int userId);
    }
}