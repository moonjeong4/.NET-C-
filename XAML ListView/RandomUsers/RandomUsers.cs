using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;

namespace WebUsers;

public static class RandomUsers
{


    static readonly HttpClient client = new();

    /// <summary>
    /// Gets an an observable list with some of the fields provided from randomuser.me
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public static ObservableCollection<User> GetUsers(int count)
    {
        Users? users = null;
        var httpResponse = client.GetAsync("https://randomuser.me/api/?results=" + count).Result;
        httpResponse.EnsureSuccessStatusCode();

        if (httpResponse.Content?.Headers.ContentType?.MediaType == "application/json")
        {
            var contentString = httpResponse.Content.ReadAsStringAsync().Result;
            users = JsonSerializer.Deserialize<Users>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        else
        {
            Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
        }
        return users?.Results ?? new ObservableCollection<User>();
    }
}
