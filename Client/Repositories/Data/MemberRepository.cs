using Client.Models;

namespace Client.Repositories.Data
{
    public class MemberRepository : GeneralRepository<string, Member>
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public MemberRepository(string request = "Members/") : base(request)
        {
            this.request = request;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7253/api/")
            };
        }
    }
}
