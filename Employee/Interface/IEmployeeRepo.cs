using Employee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Interface
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<EmployeeTable>> GetEmployees();
        Task<EmployeeTable> GetEmployee(int id);
        Task<int> CreateEmployee(EmployeeTable employee);
        Task<int> UpdateEmployee(EmployeeTable employee);
        Task<int> DeleteEmployee(int id);
    }
}
