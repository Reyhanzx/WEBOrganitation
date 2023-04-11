using Client.Models;

namespace Client.Repositories.Data
{
    public class WorkProgramRepository : GeneralRepository<int, WorkProgram>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public WorkProgramRepository(string request = "WorkProgram/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7253/api/")
            };
        }
    }
}
