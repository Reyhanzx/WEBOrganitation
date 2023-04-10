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
    public class FinancesController : BaseController<int, Finance, FinanceRepository>
    {
        public FinancesController(FinanceRepository repository) : base(repository)
        {
        }
    }
}
