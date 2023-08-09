using EduSys.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Sys.API.Controllers
{
    public class CatagoriesController : CustomBaseController
    {
        private readonly ICatagoryService _catagoryService;
        public CatagoriesController(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService; 
        }

        [HttpGet("[action]/{catagoryId}")]
        public async Task<IActionResult> GetSingleCatagoryByIdWithProductsAsync(int catagoryId)
        {
            return CreateActionResult(await _catagoryService.GetSingleCatagoryByIdWithProductsAsync(catagoryId));
        }
        
    }
}
