using Client.Models;

namespace Client.Repositories.Data
{
    public class DocumentRepository : GeneralRepository<int, Document>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public DocumentRepository(string request = "Documents/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7253/api/")
            };
        }
    }
}
