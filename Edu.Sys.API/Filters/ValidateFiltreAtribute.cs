using EduSys.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Edu.Sys.API.Filters
{
    public class ValidateFiltreAtribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erorrs = context.ModelState.Values.SelectMany(x => x.Errors).Select(o => o.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, erorrs));

            }
        }
    }

}
