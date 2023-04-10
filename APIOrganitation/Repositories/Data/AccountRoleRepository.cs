using APIOrganitation.Contexts;
using APIOrganitation.Models;

namespace APIOrganitation.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<int, AccountRole>
    {
        private readonly MyContext context;

        public AccountRoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
