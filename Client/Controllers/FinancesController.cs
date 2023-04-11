using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class FinancesController : BaseController<int, Finance, FinanceRepository>
{
    private readonly FinanceRepository repository;

    public FinancesController(FinanceRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var finance = new List<Finance>();

        if (result.Data != null)
        {
            finance = result.Data.ToList();
        }
        return View(finance);
    }
     
    [HttpGet]
    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await repository.Get(id);
        var finance = new Finance();

        if (result.Data != null)
        {
            finance.Id = result.Data.Id;
            finance.Name = result.Data.Name;
            finance.MemberNim = result.Data.MemberNim;
            finance.Date = result.Data.Date;
            finance.IncomingFunds = result.Data.IncomingFunds;
            finance.OutcomingFunds = result.Data.OutcomingFunds;
            finance.TotalFunds = result.Data.TotalFunds;
            finance.Information = result.Data.Information;
        }
        return View(finance);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //ini buat Create Post nya
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Finance finance)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(finance);
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
        var finance = new Finance();

        if (result.Data != null)
        {
            finance.Id = result.Data.Id;
            finance.Name = result.Data.Name;
            finance.MemberNim = result.Data.MemberNim;
            finance.Date = result.Data.Date;
            finance.IncomingFunds = result.Data.IncomingFunds;
            finance.OutcomingFunds = result.Data.OutcomingFunds;
            finance.TotalFunds = result.Data.TotalFunds;
            finance.Information = result.Data.Information;
        }
        return View(finance);
    }

   
    public async Task<IActionResult> Edit(Finance finance, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(finance, id);
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
        //var finance = new finance();

        //if (result.Data != null)
        //{
        //    finance.Id = result.Data.Id;
        //    finance.Name = result.Data.Name;
        //}
        //return View(finance);
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
