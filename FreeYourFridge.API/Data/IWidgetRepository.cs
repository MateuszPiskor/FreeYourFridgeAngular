using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Data
{
    public interface IWidgetRepository
    {
        Task<string> GetIndegrientsWidget(int recipeId);
    }
}
