using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KolmeoProductApi.Dtos;
using KolmeoProductApi.Services;
using KolmeoProductApi.Controllers.RequestModels;
using KolmeoProductApi.Services.Options;
using KolmeoProductApi.Services.Exceptions;

namespace KolmeoProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
            _mapper = DtoMapper.CreateMapper();
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] ProductListRequestModel requestModel)
        {
            var options = new ProductListOptions()
            {
                PageNumber = requestModel.PageNumber,
                PageSize = requestModel.PageSize,
            };

            var products = await _productService.GetAllAsync(options);


            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var product = await _productService.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }


        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductCreateRequestModel requestModel)
        {
            try
            {
                var options = new ProductCreateOptions()
                {
                    Description = requestModel.Description,
                    Name = requestModel.Name,
                    Price = requestModel.Price,
                };

                var product = await _productService.CreateAsync(options);

                return CreatedAtAction("GetProduct", new { id = product.Id }, _mapper.Map<ProductDto>(product));
            }
            catch (RequiredFieldMissingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidFieldException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
