using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IFavouredRepository
    {
        Task<Favoured> AddFavoured(Favoured favoured);
    }
}