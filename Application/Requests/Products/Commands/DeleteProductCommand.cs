using System.Threading;
using System.Threading.Tasks;
using Application.Common.Results;
using MediatR;

namespace Application.Requests.Products.Commands
{
    public class DeleteProductCommand : IRequest<Result>
    {
        private int Id { get; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
        
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
        {
            private readonly IProductService _service;

            public DeleteProductCommandHandler(IProductService service)
            {
                _service = service;
            }
            public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                return await _service.DeleteProduct(request.Id);
            }
        }
    }
}