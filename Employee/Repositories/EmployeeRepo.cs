using Employee.Interface;
using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly HomeworkContext db;
        public EmployeeRepo(HomeworkContext db) 
        {  
            this.db = db; 
        }
        public async Task<int> CreateEmployee(EmployeeTable employee)
        {
            db.Add(employee);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            return await db.SaveChangesAsync();
        }

        public Task<EmployeeTable> GetEmployee(int id)
        {
            var employee = db.Employees.SingleOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task<IEnumerable<EmployeeTable>> GetEmployees()
        {
            var employees = await db.Employees.ToListAsync();
            return employees;
        }

        public async Task<int> UpdateEmployee(EmployeeTable employee)
        {
            var existingEmployee = await GetEmployee(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Salary = employee.Salary;
                existingEmployee.Name   = employee.Name;
                existingEmployee.Email = employee.Email;
                return await db.SaveChangesAsync();
            }
            return -1;
        }
    }
}
