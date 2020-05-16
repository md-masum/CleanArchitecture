using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetProduct()
        {
            var result = _repo.GetProducts();
            return Ok(_mapper.Map<IEnumerable<ProductToReturnDto>>(result));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var result = _repo.GetProductById(id);
            
            if (result != null)
                return Ok(_mapper.Map<ProductToReturnDto>(result));
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductToCreateDto productToCreateDto)
        {
            var product = _mapper.Map<Product>(productToCreateDto);
            _repo.CreateProduct(product);
            _repo.SaveChanges();
            var productToReturn =  _mapper.Map<ProductToReturnDto>(product);
            return CreatedAtRoute(nameof(GetProductById), new {id = productToReturn.Id}, productToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductToUpdateDto productToUpdateDto)
        {
            var product = _repo.GetProductById(id);
            if (product == null)
                return NotFound();
            
            _mapper.Map(productToUpdateDto, product);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateProduct(int id, JsonPatchDocument<ProductToUpdateDto> patchDocument)
        {
            var product = _repo.GetProductById(id);
            if (product == null)
                return NotFound();

            var productToPatch = _mapper.Map<ProductToUpdateDto>(product);
            patchDocument.ApplyTo(productToPatch, ModelState);

            if (!TryValidateModel(productToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(productToPatch, product);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _repo.GetProductById(id);
            if (product == null)
                return NotFound();
            
            _repo.DeleteProduct(product);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}