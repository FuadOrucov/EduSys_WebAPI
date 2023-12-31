﻿using AutoMapper;
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

    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) :
            base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
          
        }
    
        public async Task<CustomResponseDto<List<ProductWithCatagoryDto>>>  GetProductWithCatagory()
        { 
            var products = await _productRepository.GetProductWithCatagory();
            var productsDto = _mapper.Map<List<ProductWithCatagoryDto>>(products);
            return CustomResponseDto<List<ProductWithCatagoryDto>>.Success(200, productsDto);
        }

      
    } 
}
