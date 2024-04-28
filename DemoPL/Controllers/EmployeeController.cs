using AutoMapper;
using DemoBLL.Interfaces;
using DemoDAL.Entities;
using DemoPL.Helpers;
using DemoPL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPL.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Employee/Index
        public async Task<IActionResult> Index(string SearchValue)
        {
            var Employees= Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(SearchValue))
            
                Employees =await _unitOfWork.EmployeeRepository.GetAll();
            else
            
                Employees = _unitOfWork.EmployeeRepository.SearchEmployeesByName(SearchValue);
            

            var mappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);

            return View(mappedEmp);

        }
        //[HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                ///Manual Mapping
                ///var mappedEmpm = new Employee() 
                ///{ 
                ///    Name= employeeVM.Name,
                ///    Address= employeeVM.Address,
                ///    Salary= employeeVM.Salary,
                ///    Age= employeeVM.Age,
                ///    IsActive= employeeVM.IsActive,
                ///    Department= employeeVM.Department,
                ///    Email= employeeVM.Email,
                ///    PhoneNumber= employeeVM.PhoneNumber,
                ///};

                employeeVM.ImageName = DocumentSettings.UploadFiles(employeeVM.Image, "images");

                var mappedEmpm = _mapper.Map<EmployeeViewModel , Employee>(employeeVM);

                await _unitOfWork.EmployeeRepository.Add(mappedEmpm);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

        //Employee/Details
        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();
            var Employee = await _unitOfWork.EmployeeRepository.Get(id.Value);
            if (Employee == null)
                return NotFound();
            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(Employee);
            return View(viewName, mappedEmp);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAll();

            return await Details(id, "Edit");
            //if (id == null)
            //    return BadRequest();
            //var Employee = _EmployeeRepository.Get(id.Value);
            //if (Employee == null)
            //    return BadRequest();

            //return View(Employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            //if (id != employeeVM.Id)
            //    return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                   await _unitOfWork.EmployeeRepository.Update(mappedEmp);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    //return View(Employee);
                }
            }
            return View(employeeVM);
        }

        public async Task<IActionResult>  Delete(int? id)
        {
            return await Details(id, "Delete");
            //if (id == null)
            //    return BadRequest();
            //var Employee = _EmployeeRepository.Get(id.Value);
            //if (Employee == null)
            //    return BadRequest();
            //return View(Employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (employeeVM is null)
            {
                throw new ArgumentNullException(nameof(employeeVM));
            }

            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel,Employee>(employeeVM);
                int count = await _unitOfWork.EmployeeRepository.Delete(mappedEmp);
                if (count > 0)
                    DocumentSettings.DeleteFile(employeeVM.ImageName, "images");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View(employeeVM);
            }
        }
    }   
}
