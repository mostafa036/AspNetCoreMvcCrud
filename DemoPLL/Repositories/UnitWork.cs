using DemoBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Repositories
{
    public class UnitWork : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get ; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public UnitWork(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }

    }
}
