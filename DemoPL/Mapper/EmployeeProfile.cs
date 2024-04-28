using AutoMapper;
using DemoDAL.Entities;
using DemoPL.ViewModels;

namespace DemoPL.Mapper
{
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
