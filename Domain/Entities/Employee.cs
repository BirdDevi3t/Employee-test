
namespace Domain.Entities;

public class Employee
{
    
    public int id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string designation { get; set; }
    public DateTime hiredate { get; set; }
    public decimal salary { get; set; }
    public decimal comm { get; set; }
    public int deptno { get; set; }
}
