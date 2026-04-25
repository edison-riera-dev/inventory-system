using System.Net.Http.Headers;
using Blazored.LocalStorage;
using InventorySystem.Client.Authentication;
using InventorySystem.Client.Models;
using System.Net.Http.Json;

namespace InventorySystem.Client.Services;

public class AuthService
{
    private readonly HttpClient http;
    private readonly ILocalStorageService localStorage;
    private readonly JwtAuthenticationStateProvider authStateProvider;

    public AuthService(
        HttpClient http,
        ILocalStorageService localStorage,
        JwtAuthenticationStateProvider authStateProvider)
    {
        this.http = http;
        this.localStorage = localStorage;
        this.authStateProvider = authStateProvider;
    }

    public async Task Login(LoginRequest request)
    {
        var response = await http.PostAsJsonAsync("api/auth/login", request);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Usuario o contraseña incorrectos.");

        var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

        if (result is null || string.IsNullOrWhiteSpace(result.Token))
            throw new Exception("No se recibió token.");

        await localStorage.SetItemAsync("authToken", result.Token);

        http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", result.Token);

        authStateProvider.NotifyUserAuthentication(result.Token);
    }

    public async Task Logout()
    {
        await localStorage.RemoveItemAsync("authToken");
        http.DefaultRequestHeaders.Authorization = null;
        authStateProvider.NotifyUserLogout();
    }
}