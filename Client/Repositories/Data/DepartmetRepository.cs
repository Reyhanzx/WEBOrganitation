using Client.Models;

namespace Client.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<int, Department>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public DepartmentRepository(string request = "Departments/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7253/api/")
            };
        }
    }
}
