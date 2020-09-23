using System.Collections.Generic;
using System.Threading.Tasks;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Data
{
    public interface IFridgeRepository
    {
        Task<Fridge> GetFridge(int id);
    }
}