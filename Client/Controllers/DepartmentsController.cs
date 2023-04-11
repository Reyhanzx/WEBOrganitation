using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class DepartmentsController : BaseController<int, Department, DepartmentRepository>
{
    private readonly DepartmentRepository repository;

    public DepartmentsController(DepartmentRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var department = new List<Department>();

        if (result.Data != null)
        {
            department = result.Data.ToList();
        }
        return View(department);
    }
     
    [HttpGet]
    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await repository.Get(id);
        var department = new Department();

        if (result.Data != null)
        {
            department.Id = result.Data.Id;
            department.Name = result.Data.Name;

        }
        return View(department);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //ini buat Create Post nya
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(department);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await repository.Get(id);
        var department = new Department();

        if (result.Data != null)
        {
            department.Id = result.Data.Id;
            department.Name = result.Data.Name;
        }
        return View(department);
    }

   
    public async Task<IActionResult> Edit(Department department, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(department, id);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await repository.Get(id);
        //var department = new department();

        //if (result.Data != null)
        //{
        //    department.Id = result.Data.Id;
        //    department.Name = result.Data.Name;
        //}
        //return View(department);
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Delete(id);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.StatusCode == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
        }
        return RedirectToAction(nameof(Index));
    }
}
