using Client.Models;

namespace Client.Repositories.Data
{
    public class FinanceRepository : GeneralRepository<int, Finance>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public FinanceRepository(string request = "Finances/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7253/api/")
            };
        }
    }
}
