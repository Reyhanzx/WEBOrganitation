using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class DocumentsController : BaseController<int, Document, DocumentRepository>
{
    private readonly DocumentRepository repository;

    public DocumentsController(DocumentRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var document = new List<Document>();

        if (result.Data != null)
        {
            document = result.Data.ToList();
        }
        return View(document);
    }
     
    [HttpGet]
    // Details
    public async Task<IActionResult> Details(int id)
    {
        var result = await repository.Get(id);
        var document = new Document();

        if (result.Data != null)
        {
            document.Id = result.Data.Id;
            document.MemberNim = result.Data.MemberNim;
            document.Name = result.Data.Name;
            document.Date = result.Data.Date;
            document.File = result.Data.File;
            document.DocumentTypeId = result.Data.DocumentTypeId;
            document.Information = result.Data.Information;

        }
        return View(document);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //ini buat Create Post nya
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Document document)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(document);
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
        var document = new Document();

        if (result.Data != null)
        {
            document.Id = result.Data.Id;
            document.MemberNim = result.Data.MemberNim;
            document.Name = result.Data.Name;
            document.Date = result.Data.Date;
            document.File = result.Data.File;
            document.DocumentTypeId = result.Data.DocumentTypeId;
            document.Information = result.Data.Information;
        }
        return View(document);
    }

   
    public async Task<IActionResult> Edit(Document document, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(document, id);
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
        //var document = new document();

        //if (result.Data != null)
        //{
        //    document.Id = result.Data.Id;
        //    document.Name = result.Data.Name;
        //}
        //return View(document);
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
