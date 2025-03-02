﻿namespace Simulator.DataStore.Stores
{
    using Newtonsoft.Json;
    using Simulator.DataObjects;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class UserStore : BaseStore//, IBaseStore<User>
    {
        public UserStore(string EndPoint)
        {
            base.InitializeStore(EndPoint);

        }
        public async Task<User> GetItemAsync(string id)
        {
            User user = null;
            HttpResponseMessage response = await Client.GetAsync($"/api/user/{id}");
            if (response.IsSuccessStatusCode)
            {
                response.Content.Headers.ContentType.MediaType = "application/json";
                user = await response.Content.ReadFromJsonAsync<User>();
            }
            return user;
        }

        public async Task<List<User>> GetItemsAsync()
        {
            List<User> users = null;
            HttpResponseMessage response = await Client.GetAsync("/api/user");
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<User>>(str);
            }
            return users;
        }

        
    }
}