using APIOrganitation.Base;
using APIOrganitation.Models;
using APIOrganitation.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIOrganitation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DepartmentsController : BaseController<int, Department, DepartmentRepository>
    {
        public DepartmentsController(DepartmentRepository repository) : base(repository)
        {
        }
    }
}
