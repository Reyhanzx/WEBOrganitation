using Client.Models;

namespace Client.Repositories.Data
{
    public class DocumentTypeRepository : GeneralRepository<int, DocumentType>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public DocumentTypeRepository(string request = "DocumentTypes/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7253/api/")
            };
        }
    }
}
