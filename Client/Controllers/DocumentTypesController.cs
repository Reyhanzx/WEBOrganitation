using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class DocumentTypesController : BaseController<int, DocumentType, DocumentTypeRepository>
{
    private readonly DocumentTypeRepository repository;

    public DocumentTypesController(DocumentTypeRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var documetType = new List<DocumentType>();

        if (result.Data != null)
        {
            documetType = result.Data.ToList();
        }
        return View(documetType);
    }
     
    [HttpGet]
    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await repository.Get(id);
        var documetType = new DocumentType();

        if (result.Data != null)
        {
            documetType.Id = result.Data.Id;
            documetType.Type = result.Data.Type;
        }
        return View(documetType);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //ini buat Create Post nya
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DocumentType documetType)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(documetType);
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
        var documetType = new DocumentType();

        if (result.Data != null)
        {
            documetType.Id = result.Data.Id;
            documetType.Type = result.Data.Type;
        }
        return View(documetType);
    }

   
    public async Task<IActionResult> Edit(DocumentType documetType, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(documetType, id);
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
        //var documetType = new documetType();

        //if (result.Data != null)
        //{
        //    documetType.Id = result.Data.Id;
        //    documetType.Name = result.Data.Name;
        //}
        //return View(documetType);
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
