
using Domain.Entities;

namespace Core.Interfaces;

public interface IEmployeeService
{
        Task<Employee> GetEmployeeAsync(GetEmployeeQuery query);
        Task<int> CreateEmployeeAsync(CreateEmployeeCommand command);
        Task UpdateEmployeeAsync(UpdateEmployeeCommand command);
        Task DeleteEmployeeAsync(DeleteEmployeeCommand command);

}
 