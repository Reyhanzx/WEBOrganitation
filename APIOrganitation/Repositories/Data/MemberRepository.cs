using APIOrganitation.Models;
using APIOrganitation.Contexts;


namespace APIOrganitation.Repositories.Data
{
    public class MemberRepository : GeneralRepository<string, Member>
    {
        private readonly MyContext context;

        public MemberRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
