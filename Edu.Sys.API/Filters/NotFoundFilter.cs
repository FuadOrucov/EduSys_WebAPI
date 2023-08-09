using EduSys.Core.DTOs;
using EduSys.Core.Models;
using EduSys.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Edu.Sys.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter  where T: BaseEntitiy
    {
        private readonly IService<T> _service;
        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }
    
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue==null)
            {
                await next.Invoke();
                return;
            }
            var id =(int) idValue;
            var anyEntity = await _service.AnyAsync(o => o.Id == id);
            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name} ({id}) not found"));
        }
    }
}
