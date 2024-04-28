using DemoDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DemoPL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //Role/Index
        public async Task<IActionResult> Index(string SearchValue)
        {
            var roles = Enumerable.Empty<IdentityRole>().ToList();
            if (string.IsNullOrEmpty(SearchValue))
                roles.AddRange(_roleManager.Roles);
            else

                roles.Add(await _roleManager.FindByNameAsync(SearchValue));
            return View(roles);

        }

        //[HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        //Employee/Details

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            return View(viewName, role);

        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, IdentityRole updatedRole)
        {
            if (id != updatedRole.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    role.Name = updatedRole.Name;
                    await _roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    //return View(Employee);
                }
            }
            return View(updatedRole);
        }

        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IdentityRole deletedRole)
        {
            if (id != deletedRole.Id)
                return BadRequest();

            try
            {
                var user = await _roleManager.FindByIdAsync(id);

                await _roleManager.DeleteAsync(user);// throw exception

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View(deletedRole);
            }
        }
    }
}
