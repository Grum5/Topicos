
namespace agenda2.ViewModel; 

using Model;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

internal partial class RegisterViewModel : ObservableObject {

    /* Atributos ligados por Binding TwoWay */
    [ObservableProperty]
    private string? email;

    [ObservableProperty]
    private string? username;

    [ObservableProperty]
    private string? password;

    [ObservableProperty]
    private string? confirmPassword;


    [RelayCommand]
    private async Task Register() {
        /*
         * Metodo para registrar el usuario
         */

        if (IsValid) {

            // Intentar registrar el usuario al SecureStorage
            try {

                // Guardar los datos del usuario
                var user = new User {
                    email = Email,
                    username = Username,
                    password = Password
                };

                // Registrar los datos del usuario en SecureStorage
                await SecureStorage.SetAsync("email", user.email);
                await SecureStorage.SetAsync("username", user.username);
                await SecureStorage.SetAsync("password", user.password);

                // Mostrar en pantalla un DisplayAlert para hacer saber que se registro el usuario
                await Shell.Current.DisplayAlert("Usuario registrado", $"Usuario {Username}", "OK");
                
                // Volver al Login
                await Shell.Current.GoToAsync("//LoginPage");
            }

            // Si falla mostrar un DisplayAlert con el error
            catch (Exception ex) {
                await Shell.Current.DisplayAlert("Error", $"{ex}", "OK");
            }

        }
        else {
            await Shell.Current.DisplayAlert("Error chulo", "No es valido\nSoporta <(o.o)>", "OK");
        }
    }

    [RelayCommand]
    private async Task ReturnToLogin() {
        /* Comando para regresar el Login */
        await Shell.Current.GoToAsync("//LoginPage");
    }

    // Propiedad booleana para validar los Entry
    private bool IsValid 
        => !string.IsNullOrWhiteSpace(Username)
        && !string.IsNullOrWhiteSpace(Password)
        && Password == ConfirmPassword;
        // && Password.Length > 8
            
}

