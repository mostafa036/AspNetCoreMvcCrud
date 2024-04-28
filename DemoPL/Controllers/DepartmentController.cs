using DemoBLL.Interfaces;
using DemoBLL.Mock_Repositories;
using DemoBLL.Repositories;
using DemoDAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DemoPL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        //Department/Index
        public async Task<IActionResult> Index()
        {
            //// ViewData
            //ViewData["message"] = "Hellow view data";

            //// ViewBag
            //ViewBag.Hamada = "Hellow every one";
 
            var departments =await  _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }
        //[HttpGet]
        public  IActionResult Create()
        {
            return  View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.DepartmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        //Department/Details
        public async Task<IActionResult> Details(int? id , string viewName ="Details")
        {
            if (id == null)
                return NotFound();
            var department = await _unitOfWork.DepartmentRepository.Get(id.Value);
            if (department == null)
                return NotFound();
            return View( viewName ,department);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id , "Edit");
            //if (id == null)
            //    return BadRequest();
            //var department = _departmentRepository.Get(id.Value);
            //if (department == null)
            //    return BadRequest();

            //return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int? id , Department department)
        {
            if (id != department.Id)
                return BadRequest();
            
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.DepartmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    //return View(department);
                }
            }
            return View(department);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id,"Delete");
            //if (id == null)
            //    return BadRequest();
            //var department = _departmentRepository.Get(id.Value);
            //if (department == null)
            //    return BadRequest();
            //return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id,Department department)
        {
            if (id != department.Id )
                return BadRequest();
            try
            {
                await _unitOfWork.DepartmentRepository.Delete(department);
                return RedirectToAction(nameof (Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View(department);
            }
        }
    }
}
