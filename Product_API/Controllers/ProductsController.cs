﻿using Microsoft.AspNetCore.Mvc;
using Product.Domain.Entities;
using Product_API.Infrastructure.Repositories;

namespace Product_API.Controllers
{
    [Route("Products/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductModelDTO product)
        {
            return Ok(_repository.Add(product));
        }
    }
}
