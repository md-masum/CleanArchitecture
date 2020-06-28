using System.Threading.Tasks;
using Application.Requests.Products;
using Application.Requests.Products.Commands;
using Application.Requests.Products.Queries;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductController(IProductRepo repo, IMapper mapper, IMediator mediator)
        {
            _repo = repo;
            _mapper = mapper;
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _mediator.Send(new GetProductQuery()));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var result = _mediator.Send(new GetProductByIdQuery(id));
            
            if (result != null)
                return Ok(result);
            
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var (result, productToReturnDto) = await _mediator.Send(command);
            if(result.Succeeded)
                return CreatedAtRoute(nameof(GetProductById), new {id = productToReturnDto.Id}, productToReturnDto);
            
            return BadRequest(result.Errors);
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateProduct(int id, ProductToUpdateDto productToUpdateDto)
        //{
        //    var product = _repo.GetProductById(id);
        //    if (product == null)
        //        return NotFound();

        //    _mapper.Map(productToUpdateDto, product);
        //    _repo.SaveChanges();
        //    return NoContent();
        //}

        //[HttpPatch("{id}")]
        //public IActionResult PartialUpdateProduct(int id, JsonPatchDocument<ProductToUpdateDto> patchDocument)
        //{
        //    var product = _repo.GetProductById(id);
        //    if (product == null)
        //        return NotFound();

        //    var productToPatch = _mapper.Map<ProductToUpdateDto>(product);
        //    patchDocument.ApplyTo(productToPatch, ModelState);

        //    if (!TryValidateModel(productToPatch))
        //        return ValidationProblem(ModelState);

        //    _mapper.Map(productToPatch, product);
        //    _repo.SaveChanges();
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            if (result.Succeeded)
                return Ok("delete successfully");
            
            return BadRequest(result.Errors);
        }
    }
}