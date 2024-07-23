using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        try
        {

            var query = new GetEmployeeQuery { id = id };
            var employee = await _employeeService.GetEmployeeAsync(query);
            if (employee == null)
                return NotFound();

            return Ok(employee);

        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        try
        {
            var id = await _employeeService.CreateEmployeeAsync(command);
            return Ok(new { Id = id });
        }
        catch (System.Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
    {
        try
        {

            await _employeeService.UpdateEmployeeAsync(command);
            return Ok();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _employeeService.DeleteEmployeeAsync(command);
            return Ok();
        }
        catch (System.Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        }
    }
}

