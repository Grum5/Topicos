
namespace agenda2.Services;

using System.Net.Http.Json;
using agenda2.Model;

public class AuthService {
    
    private readonly HttpClient _http;
    private const string API_URL = "http://192.168.88.54:8080"; // IP de mi laptop en mi red local

    public AuthService() {
        _http = new HttpClient {
            BaseAddress = new Uri(API_URL)
        };
    }

    public async Task<bool> LoginAsync(string user, string password) {

        try {

            var login = new UserAuth {
                usuario = user,
                clave = password
            };
            var response = await _http.PostAsJsonAsync($"{API_URL}/auth", login);

            if (response.IsSuccessStatusCode) {

                return true;
            }

            var errorMsgn = await response.Content.ReadAsStringAsync();
            await Shell.Current.DisplayAlert("Error dentro del try", $"{errorMsgn}", "OK");
            return false;
        }
        catch (Exception ex) {
            await Shell.Current.DisplayAlert("Error desde AuthService.cs", $"{ex}", "OK");
        }

        return false;
    }
}
