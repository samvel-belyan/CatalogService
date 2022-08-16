using Application.Interfaces;
using CatalogApi.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] FilterModel filter)
    {
        var products = await _productService.GetProducts(filter.CategoryId, filter.Skip, filter.Count);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        if (product is null)
        {
            return BadRequest("Product cannot be null");
        }

        var result = await _productService.AddProduct(product);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(Product product)
    {
        if (product is null)
        {
            return BadRequest("Product cannot be null");
        }

        var result = await _productService.UpdateProduct(product);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return Ok(HttpStatusCode.NoContent);
    }

    [HttpGet]
    [Route("{id}/properties")]
    public IActionResult GetProperties(int id)
    {
        var data = new
        {
            Id = id,
            Name = "Charger",
            Brand = "Nokia"
        };

        return Ok(data);
    }

    [HttpGet]
    [Route("{id}/details")]
    public async Task<IActionResult> GetDetailsAsync(int id)
    {
        var product = await _productService.GetProduct(id);
        return Ok(product);
    }
}
