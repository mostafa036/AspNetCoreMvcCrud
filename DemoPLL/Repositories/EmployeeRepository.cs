using DemoBLL.Interfaces;
using DemoDAL.Contexts;
using DemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        private readonly MVCAppContext _dbContext;

        public EmployeeRepository(MVCAppContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Employee> GetEmployeesByDepartmentname(string departmentname)
        {
            //_dbContext
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetEmployeesByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> SearchEmployeesByName(string name)

        =>  _dbContext.Employees.Where(E => E.Name.Contains(name));
        
    }
}
