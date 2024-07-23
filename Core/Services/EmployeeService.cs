using Core.Interfaces;
using Domain.Entities;

namespace Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> GetEmployeeAsync(GetEmployeeQuery query)
    {
        return await _employeeRepository.GetByIdAsync(query.id);
    }

    public async Task<int> CreateEmployeeAsync(CreateEmployeeCommand command)
    {
        var employee = new Employee
        {
            firstname = command.firstname,
            lastname = command.lastname,
            designation = command.designation,
            hiredate = DateTime.UtcNow,
            salary = command.salary,
            comm = command.comm,
            deptno = command.deptno

        };
        return await _employeeRepository.AddAsync(employee);
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeCommand command)
    {
        var employee = await _employeeRepository.GetByIdAsync(command.id);
        if (employee == null)
            throw new Exception("Employee not found");

            employee.firstname = command.firstname;
            employee.lastname = command.lastname;
            employee.designation = command.designation;
            employee.hiredate = DateTime.UtcNow;
            employee.salary = command.salary;
            employee.comm = command.comm;
            employee.deptno = command.deptno;

        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteEmployeeAsync(DeleteEmployeeCommand command)
    {
        await _employeeRepository.DeleteAsync(command.Id);
    }

}
