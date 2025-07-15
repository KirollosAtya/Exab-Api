using Microsoft.AspNetCore.Authorization;

namespace Exab.Test.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "Category.Create")]
    public virtual async Task<IActionResult> Create(CreateCategoryCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPut("{id}")]
    [Authorize(Policy = "Category.Update")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand request)
    {
       
        var result = await _mediator.Send(request);
        if (!result)
            return NotFound();

        return Ok(); 
    }
    [HttpDelete("{id}")]
    [Authorize(Policy = "Category.Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand(id));

        if (!result)
            return NotFound();

        return Ok(); 
    }
    [HttpGet]
    [Authorize(Policy = "Category.Read")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery getAllCategoriesQuery)
    {
        var result = await _mediator.Send(getAllCategoriesQuery);
        return Ok(result);
    }
    [HttpGet("{id}")]
    [Authorize(Policy = "Category.Read")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
