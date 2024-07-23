using Domain.Entities;

namespace Core;

public class DeleteEmployeeCommand:Employee
{
    public int Id { get; set; }
    
}
