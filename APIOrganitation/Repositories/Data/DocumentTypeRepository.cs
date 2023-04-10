using APIOrganitation.Models;
using APIOrganitation.Contexts;

namespace APIOrganitation.Repositories.Data
{
    public class DocumentTypeRepository : GeneralRepository<int, DocumentType>
    {
        private readonly MyContext context;

        public DocumentTypeRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
