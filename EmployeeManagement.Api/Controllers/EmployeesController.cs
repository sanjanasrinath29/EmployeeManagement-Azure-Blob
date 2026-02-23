using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _repository;
    private readonly BlobService _blobService;
    public EmployeesController(IEmployeeRepository repository, BlobService blobService)
    {
        _repository = repository;
        _blobService = blobService;
    }

    // GET: api/employees
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repository.GetAllAsync());

    // GET: api/employees/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    // POST: api/employees
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Employee employee, IFormFile? file)
    {
        if (file != null && file.Length > 0)
        {
            var blobUrl = await _blobService.UploadFileAsync(file);
            employee.ProfileImageUrl = blobUrl;
        }

        var id = await _repository.CreateAsync(employee);
        employee.Id = id;

        return CreatedAtAction(nameof(GetById), new { id }, employee);
    }

    // PUT: api/employees/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] Employee employee, IFormFile? file)
    {
        if (id != employee.Id)
            return BadRequest("ID mismatch");

        var existingEmployee = await _repository.GetByIdAsync(id);
        if (existingEmployee == null)
            return NotFound();

        // If new image uploaded
        if (file != null && file.Length > 0)
        {
            var blobUrl = await _blobService.UploadFileAsync(file);
            employee.ProfileImageUrl = blobUrl;
        }
        else
        {
            // Keep old image
            employee.ProfileImageUrl = existingEmployee.ProfileImageUrl;
        }

        var updated = await _repository.UpdateAsync(employee);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
    
}