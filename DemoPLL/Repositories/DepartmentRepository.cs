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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MVCAppContext dbContext):base(dbContext)
        {

        }
    }
}
