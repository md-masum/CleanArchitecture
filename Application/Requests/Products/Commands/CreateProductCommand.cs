using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Application.Common.Results;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;

namespace Application.Requests.Products.Commands
{
    public class CreateProductCommand : IRequest<(Result, ProductToReturnDto)>, IMapFrom<Product>
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Style { get; set; }
        public float Price { get; set; }
        public byte Stock { get; set; }
        
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, (Result, ProductToReturnDto)>
        {
            private readonly IProductService _productService;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }
            public async Task<(Result, ProductToReturnDto)> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<CreateProductCommand, Product>(request);
                
                var result = await _productService.CreateProduct(product);
                
                if(result.Succeeded)
                {
                    var productToReturn = _mapper.Map<Product, ProductToReturnDto>(product);

                    return (result, productToReturn);
                }
                else
                {
                    return (result, null);
                }
            }
        }
    }
}