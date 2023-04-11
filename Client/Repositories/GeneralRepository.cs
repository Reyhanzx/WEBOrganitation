using Client.Repositories.Interface;
using Client.ViewModels;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Client.Repositories;

public class GeneralRepository<Key, Entity> : IRepository<Key, Entity>
    where Entity : class
{
    private readonly string request;
    private readonly HttpClient _httpClient;
    public GeneralRepository(string request)
    {
        this.request = request;
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7253/api/")
        };
    }

    public async Task<RespondStatusVM> Delete(Key id)
    {
        RespondStatusVM entityVM = null;
        using (var response = _httpClient.DeleteAsync(request+id).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<RespondStatusVM>(apiResponse);
        }
        return entityVM;
    }

    public async Task<ListVM<Entity>> Get()
    {
        ListVM<Entity> listVM  = null;
        using (var response = await _httpClient.GetAsync(request))
        {
            string apiResponse =await response.Content.ReadAsStringAsync();
            listVM = JsonConvert.DeserializeObject<ListVM<Entity>>(apiResponse);
        }
        return listVM;
    }

    public async Task<RespondVM<Entity?>> Get(Key id)
    {
        RespondVM<Entity> entity = null;
        using (var response = await _httpClient.GetAsync(request+id))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<RespondVM<Entity>>(apiResponse);
        }
        return entity;
    }

    public async Task<RespondStatusVM> Post(Entity entity)
    {
        RespondStatusVM entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = _httpClient.PostAsync(request, content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<RespondStatusVM>(apiResponse);
        }
        return entityVM;
    }

    public async Task<RespondStatusVM> Put(Entity entity, Key id)
    {
        RespondStatusVM entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = _httpClient.PutAsync(request, content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<RespondStatusVM>(apiResponse);
        }
        return entityVM;
    }
}

