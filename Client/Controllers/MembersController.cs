using Client.Base;
using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class MembersController : BaseController<string, Member, MemberRepository>
{
    private readonly MemberRepository repository;

    public MembersController(MemberRepository repository) : base(repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var member = new List<Member>();

        if (result.Data != null)
        {
            member = result.Data.ToList();
        }
        return View(member);
    }
     
    [HttpGet]
    // Details
    public async Task<IActionResult> Details(string id)
    {
        var result = await repository.Get(id);
        var member = new Member();

        if (result.Data != null)
        {
            member.Nim = result.Data.Nim;
            member.Name = result.Data.Name;
            member.Major = result.Data.Major;
            member.BirthDate = result.Data.BirthDate;
            member.TitleName = result.Data.TitleName;
            member.PhoneNumber = result.Data.PhoneNumber;
            member.Address = result.Data.Address;
            member.Email = result.Data.Email;
        }
        return View(member);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    //ini buat Create Post nya
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Member member)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Post(member);
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
    public async Task<IActionResult> Edit(string id)
    {
        var result = await repository.Get(id);
        var member = new Member();

        if (result.Data != null)
        {
            member.Nim = result.Data.Nim;
            member.Name = result.Data.Name;
            member.Major = result.Data.Major;
            member.BirthDate = result.Data.BirthDate;
            member.TitleName = result.Data.TitleName;
            member.PhoneNumber = result.Data.PhoneNumber;
            member.Address = result.Data.Address;
            member.Email = result.Data.Email;
        }
        return View(member);
    }

   
    public async Task<IActionResult> Edit(Member member, string id)
    {
        if (ModelState.IsValid)
        {
            var result = await repository.Put(member, id);
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
    public async Task<IActionResult> Delete(string id)
    {
        var result = await repository.Get(id);
        //var member = new member();

        //if (result.Data != null)
        //{
        //    member.Id = result.Data.Id;
        //    member.Name = result.Data.Name;
        //}
        //return View(member);
        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(string id)
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
