using DemoBLL.Interfaces;
using DemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Mock_Repositories
{
    public class MockDepartmentRepository : IDepartmentRepository
    {
        
        Task<int> IGenericRepositories<Department>.Add(Department item)
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericRepositories<Department>.Delete(Department item)
        {
            throw new NotImplementedException();
        }

        Task<Department> IGenericRepositories<Department>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Department>> IGenericRepositories<Department>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericRepositories<Department>.Update(Department item)
        {
            throw new NotImplementedException();
        }
    }
}
