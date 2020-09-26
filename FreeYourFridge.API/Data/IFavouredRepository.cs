using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IFavouredRepository
    {
        Task<Favoured> AddFavoured(Favoured favoured);
        Task<IEnumerable<Favoured>> GetFavoureds();
        Task<string> GetRecipesByIds(string idsString);
    }
}