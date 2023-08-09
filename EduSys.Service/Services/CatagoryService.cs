using AutoMapper;
using EduSys.Core.DTOs;
using EduSys.Core.Models;
using EduSys.Core.Repositories;
using EduSys.Core.Services;
using EduSys.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Service.Services
{
    public class CatagoryService : Service<Catagory>, ICatagoryService
    {
        private readonly ICatagoryRepository _catagoryRepositroy;
        private readonly IMapper _mapper;
        public CatagoryService(IGenericRepository<Catagory> repository,IUnitOfWork unitOfWork,ICatagoryRepository catagoryRepositroy, IMapper mapper):
            base(repository, unitOfWork)
        {
            _catagoryRepositroy = catagoryRepositroy;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CatagoryWithProductDto>> GetSingleCatagoryByIdWithProductsAsync(int catagoryId)
        {
            var products =  await _catagoryRepositroy.GetSingleCatagoryByIdWithProductsAsync(catagoryId);
            var catagoryDto = _mapper.Map<CatagoryWithProductDto>(products);
            return CustomResponseDto<CatagoryWithProductDto>.Success(200, catagoryDto);
        }
    }
}
