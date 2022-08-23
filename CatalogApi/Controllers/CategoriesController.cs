using Application.Interfaces;
using CatalogApi.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogApi.Controllers;

[ApiController]
[Route("api/categories", Name = "general")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly LinkGenerator _linkGenerator;
    private readonly ILogger _logger;

    public CategoriesController(ICategoryService categoryService, LinkGenerator linkGenerator, ILogger logger)
    {
        _categoryService = categoryService;
        _linkGenerator = linkGenerator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        if (category is null)
        {
            _logger.LogError("Category update failed");
            return BadRequest("Category cannot be null");
        }

        var result = await _categoryService.AddCategory(category);

        return CreatedAtRoute("general", new { id = category.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        if (category is null)
        {
            _logger.LogError("Category update failed");
            return BadRequest("Category cannot be null");
        }

        var result = await _categoryService.UpdateCategory(category);
        return Ok(new LinkDto(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateCategory), values: new { id = category.Id}),
                    "self",
                    "GET"));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategory(id);
        return Ok(HttpStatusCode.NoContent);
    }
}
