
using Microsoft.AspNetCore.Mvc;
using DemoApi.Models;
using DemoApi.DTOs;

namespace DemoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static int _nextId = 1;

    /// <summary>
    /// Creates a new product with proper [FromBody] binding to avoid HTTP 415
    /// </summary>
    /// <param name="productDto">The product data</param>
    /// <returns>The created product</returns>
    /// <response code="201">Returns the newly created product</response>
    /// <response code="415">When the Content-Type header is not application/json</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    public ActionResult<Product> Create([FromBody] ProductCreateDto productDto)
    {
        // Simulate creating a product
        var product = new Product
        {
            Id = _nextId++,
            Name = productDto.Name,
            Price = productDto.Price
        };

        return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
    }

    // Example of incorrect usage that would cause HTTP 415
    // Uncomment to test the error
    /*
    [HttpPost("wrong")]
    public ActionResult<Product> CreateWrong(ProductCreateDto productDto) // Missing [FromBody]
    {
        return BadRequest();
    }
    */
}
