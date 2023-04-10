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
    public class WorkProgramController : BaseController<int, WorkProgram, WorkProgramRepository>
    {
        public WorkProgramController(WorkProgramRepository repository) : base(repository)
        {
        }
    }
}
