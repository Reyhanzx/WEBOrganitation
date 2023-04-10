using APIOrganitation.Models;
using APIOrganitation.Contexts;

namespace APIOrganitation.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<int, Department>
    {
        private readonly MyContext context;

        public DepartmentRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
