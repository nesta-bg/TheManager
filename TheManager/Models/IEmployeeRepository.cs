using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheManager.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
    }
}
