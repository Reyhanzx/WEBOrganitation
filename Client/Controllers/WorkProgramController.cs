using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class WorkProgramController : BaseController<int, WorkProgram, WorkProgramRepository>
{
    private readonly WorkProgramRepository repository;

    public WorkProgramController(WorkProgramRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var workProgram = new List<WorkProgram>();

        if (result.Data != null)
        {
            workProgram = result.Data.ToList();
        }
        return View(workProgram);
    }
     
    [HttpGet]
    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await repository.Get(id);
        var workProgram = new WorkProgram();

        if (result.Data != null)
        {
            workProgram.Id = result.Data.Id;
            workProgram.Name = result.Data.Name;
            workProgram.MemberNim = result.Data.MemberNim;
            workProgram.DepartmentId = result.Data.DepartmentId;
            workProgram.Start_Date = result.Data.Start_Date;
            workProgram.End_Date = result.Data.End_Date;
            workProgram.Budget = result.Data.Budget;
            workProgram.Description = result.Data.Description;
        }
        return View(workProgram);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //ini buat Create Post nya
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(WorkProgram workProgram)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(workProgram);
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
        var workProgram = new WorkProgram();

        if (result.Data != null)
        {
            workProgram.Id = result.Data.Id;
            workProgram.Name = result.Data.Name;
            workProgram.MemberNim = result.Data.MemberNim;
            workProgram.DepartmentId = result.Data.DepartmentId;
            workProgram.Start_Date = result.Data.Start_Date;
            workProgram.End_Date = result.Data.End_Date;
            workProgram.Budget = result.Data.Budget;
            workProgram.Description = result.Data.Description;
        }
        return View(workProgram);
    }

   
    public async Task<IActionResult> Edit(WorkProgram workProgram, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(workProgram, id);
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
        //var workProgram = new workProgram();

        //if (result.Data != null)
        //{
        //    workProgram.Id = result.Data.Id;
        //    workProgram.Name = result.Data.Name;
        //}
        //return View(workProgram);
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
