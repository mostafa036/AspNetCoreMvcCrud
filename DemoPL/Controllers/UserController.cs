using DemoBLL.Interfaces;
using DemoDAL.Entities;
using DemoPL.Helpers;
using DemoPL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DemoPL.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

        //User/Index
        public async Task<IActionResult> Index(string SearchValue)
        {
            var users = Enumerable.Empty<ApplicationUser>().ToList();
            if (string.IsNullOrEmpty(SearchValue))
                users.AddRange(_userManager.Users);
            else

                users.Add(await _userManager.FindByEmailAsync(SearchValue));
            return View(users);

        }
        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetAll();
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ///Manual Mapping
        //        ///var mappedEmpm = new Employee() 
        //        ///{ 
        //        ///    Name= employeeVM.Name,
        //        ///    Address= employeeVM.Address,
        //        ///    Salary= employeeVM.Salary,
        //        ///    Age= employeeVM.Age,
        //        ///    IsActive= employeeVM.IsActive,
        //        ///    Department= employeeVM.Department,
        //        ///    Email= employeeVM.Email,
        //        ///    PhoneNumber= employeeVM.PhoneNumber,
        //        ///};

        //        employeeVM.ImageName = DocumentSettings.UploadFiles(employeeVM.Image, "images");

        //        var mappedEmpm = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

        //        await _unitOfWork.EmployeeRepository.Add(mappedEmpm);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(employeeVM);
        //}

        //Employee/Details

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();
            var users = await _userManager.FindByIdAsync(id);
            if (users == null)
                return NotFound();

            return View(viewName, users);

        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
            ///if (id == null)
            ///    return BadRequest();
            ///var Employee = _EmployeeRepository.Get(id.Value);
            ///if (Employee == null)
            ///    return BadRequest();
            ///return View(Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, ApplicationUser updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var user =await _userManager.FindByIdAsync(id);
                    user.UserName = updatedUser.UserName;
                    user.PhoneNumber = updatedUser.PhoneNumber;

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    //return View(Employee);
                }
            }
            return View(updatedUser);
        }

        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
            ///if (id == null)
            ///    return BadRequest();
            ///var Employee = _EmployeeRepository.Get(id.Value);
            ///if (Employee == null)
            ///    return BadRequest();
            ///return View(Employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete( string id, ApplicationUser deletedUser)
        {
            if (id != deletedUser.Id)
                return BadRequest();

            try
            {
                var user = await _userManager.FindByIdAsync(id);

                await _userManager.DeleteAsync(user);// throw exception

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View(deletedUser);
            }
        }
    }
}
