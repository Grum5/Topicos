namespace agenda2.ViewModel; 

using Model;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

// DEBUGGING 
// using CommunityToolkit.Maui.Alerts;

internal partial class LoginViewModel : ObservableObject {

    /* Atributos ligados por Binding TwoWay */
    [ObservableProperty]
    private string? username;

    [ObservableProperty]
    private string? password;

    private readonly INavigation _navigation;

    public LoginViewModel(INavigation navigation) {

        _navigation = navigation;

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

            // Hacer una llamada async a SecureStorage para obtener el usuario y contraseña
            var user = new User {
                username = await SecureStorage.GetAsync("username"),
                password = await SecureStorage.GetAsync("password"),
            };

            // Verificar que los Entry coincidan con los del SecureStorage
            if (IsValid && user.username == Username && user.password == Password) {

                // Marcar como preferencias que se inicio sesión
                await SecureStorage.SetAsync("IsLoggedIn", "true");

                // Viajar a la agenda
                // DEBUGGING
                await Shell.Current.DisplayAlert("LOGIN CORRECTO", "El login fue correcto", "OK");
                await Shell.Current.GoToAsync("//AgendaPage");

            }
            else {
                await Shell.Current.DisplayAlert("Login incorrecto", "El login no se concluyo", "OK");
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
