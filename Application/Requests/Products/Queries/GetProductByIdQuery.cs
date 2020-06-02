using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Application.Requests.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductToReturnDto>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        private int Id { get; }
        
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductToReturnDto>
        {
            private readonly IProductService _productService;
            private readonly Mapper _mapper;

            public GetProductByIdQueryHandler(IProductService productService, Mapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }
            public async Task<ProductToReturnDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productService.GetProductById(request.Id);
                return _mapper.Map<ProductToReturnDto>(product);
            }
        }
    }
}