
using Client.Models;
using Client.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories.Data;

public class AccountRepository : GeneralRepository<string, Account>
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public AccountRepository(string request="Accounts/") : base(request)
    {
        this.request = request;
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7253/api/")
        };
    }
    public async Task<RespondVM<string>> Login(LoginVM entity)
    {
        RespondVM<string> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = _httpClient.PostAsync("Login", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<RespondVM<string>>(apiResponse);
        }
        return entityVM;
    }

    //public async Task<RespondStatusVM> Register(RegisterVM entity)
    //{
    //    RespondStatusVM entityVM = null;
    //    StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/Json");
    //    using (var response = await _httpClient.PostAsync(request + "register", content))
    //    {
    //        string apiResponse = await response.Content.ReadAsStringAsync();
    //        entityVM = JsonConvert.DeserializeObject<RespondStatusVM>(apiResponse);
    //    }
    //    return entityVM;
    //}
}
