using APIOrganitation.Contexts;
using APIOrganitation.Models;

namespace APIOrganitation.Repositories.Data
{
    public class RoleRepository : GeneralRepository<int, Role>
    {
        private readonly MyContext context;

        public RoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
