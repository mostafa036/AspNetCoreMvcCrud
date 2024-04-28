using DemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepositories<Employee>
    {
        IQueryable<Employee> GetEmployeesByDepartmentName(string departmentName);

        IQueryable<Employee> SearchEmployeesByName(string name);
    }
}
