using EduSys.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Service.Validations
{
    public class ProductDtoValidator: AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(o => o.Name).NotNull().WithMessage("{Property Name} is requierd").NotEmpty().WithMessage("{Property Name} is requierd");
            RuleFor(o=>o.Price).InclusiveBetween(1, int.MaxValue).WithMessage("Price must be greater than 0");
            RuleFor(o=>o.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("Stock must be greater than 0");
            RuleFor(o=>o.CatagoryId).InclusiveBetween(1, int.MaxValue).WithMessage("CatagoryId must be greater than 0");
        }
    }
}
