namespace agenda2.ViewModel; 

using Model;
using Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

internal partial class LoginViewModel : ObservableObject {

    /* Atributos ligados por Binding TwoWay */
    [ObservableProperty]
    private string? username;

    [ObservableProperty]
    private string? password;

    private readonly INavigation _navigation;
    private readonly AuthService _authService;

    public LoginViewModel(INavigation navigation) {

        _navigation = navigation;
        _authService = new AuthService();

        CheckIfUserIsLoggedIn();
    }

    private void CheckIfUserIsLoggedIn() {

        bool isLoggedIn = SecureStorage.GetAsync("IsLoggedIn").Result == "true";

        if (isLoggedIn)
        {
            // Esto se ejecuta inmediatamente si ya inició sesión
            GoToMainPage();
        }
    }

    private async void GoToMainPage()
    {
        // Asegúrate de que estés usando Shell
        await Shell.Current.GoToAsync("//AgendaPage");
    }

    [RelayCommand]
    private async Task Login() {
        /* 
         * Metodo encargado de obtener los datos del usuario para inciar sesión
         */

        // Intentar obtener el usuario
        try {
            var success = await _authService.LoginAsync(Username, Password);

            if (success) {
                await Shell.Current.DisplayAlert("LOGIN CORRECTO", "El login fue correcto", "OK");
                await Shell.Current.GoToAsync("//AgendaPage");
            }
            else {
                await Shell.Current.DisplayAlert("Error", "Login fallido", "OK");
            }
        }
        catch (Exception ex) {
            await Shell.Current.DisplayAlert("Error", $"{ex}", "OK");
        }
    }

    [RelayCommand]
    private async Task NavigateToRegister() {
        /* Metodo para viajar al RegisterPage */
        
        await Shell.Current.GoToAsync("RegisterPage");
    }

    [RelayCommand]
    private async Task NavigateToRecover() {
        /* Metodo para viajar al RecoverPage */

        await Shell.Current.GoToAsync("RecoverPage");
    }

    // Propiedad booleana para validar los Entry
    private bool IsValid 
        => !string.IsNullOrWhiteSpace(Username)
        && !string.IsNullOrWhiteSpace(Password);

}
