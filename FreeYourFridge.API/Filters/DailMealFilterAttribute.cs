using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace FreeYourFridge.API.Filters
{
    public class DailMealFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;
            if (result.Value == null || result.StatusCode < 200 || result.StatusCode >= 300)
            {
                await next();
                return;
            }

            var (dmeal, iRecipe) = ((Models.DailyMeal, ExternalModels.IncomingRecipe))result.Value;
            var map = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            var mMeal = map.Map<DTOs.DailyMealDetailedDto>(dmeal);
            result.Value = map.Map(iRecipe, mMeal);

            await next();
        }
    }
}
