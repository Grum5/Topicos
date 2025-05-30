namespace agenda2.ViewModel; 

using Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

internal partial class LoginViewModel : ObservableObject {

    /* Atributos ligados por Binding TwoWay */
    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    private readonly INavigation _navigation;
    private readonly UserService _userService;

    public LoginViewModel(INavigation navigation) {

        // Rellenar los parametros como strings vacios
        Username = string.Empty;
        Password = string.Empty;

        _navigation = navigation;
        _userService = new UserService();

        CheckIfUserIsLoggedIn();
    }

    private void CheckIfUserIsLoggedIn() {

        bool isLoggedIn = SecureStorage.GetAsync("IsLoggedIn").Result == "true";

        if (isLoggedIn) {

            // Esto se ejecuta inmediatamente si ya inició sesión
            GoToMainPage();
        }
    }

    private async void GoToMainPage() {
        
        // Vaciar los Input
        Username = string.Empty;
        Password = string.Empty;

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
            var success = await _userService.LoginAsync(Username, Password);

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
        
        // Desde LoginViewModel o la página de login cuando navegas a RegisterPage
        await Shell.Current.GoToAsync("RegisterPage", true, new Dictionary<string, object> {
            ["UserService"] = _userService
        });
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
