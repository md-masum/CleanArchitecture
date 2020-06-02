using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Application.Requests.Products.Queries
{
    public class GetProductQuery :IRequest<IList<ProductToReturnDto>>
    {
        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IList<ProductToReturnDto>>
        {
            private readonly IProductService _productService;
            private readonly Mapper _mapper;

            public GetProductQueryHandler(IProductService productService, Mapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }
            
            public async Task<IList<ProductToReturnDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _productService.GetProducts();
                return _mapper.Map<IList<ProductToReturnDto>>(product);
            }
        }
    }
}