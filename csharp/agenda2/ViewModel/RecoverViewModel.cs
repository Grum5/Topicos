namespace agenda2.ViewModel; 

using Model;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

// DEBUGGING 
// using CommunityToolkit.Maui.Alerts;

internal partial class RecoverViewModel : ObservableObject {

    /* Atributos ligados por Binding TwoWay */
    [ObservableProperty]
    private string? email;


    [RelayCommand]
    private async Task Recover() {
        /* 
         * Metodo para recuperar el usuario 
         * - Este metodo debe ligarse a un API
         * - Se usa como test, esto no debe ser implementado en producción
         */
        
        try {

            var user = new User {
                email = await SecureStorage.GetAsync("email"),
                username = await SecureStorage.GetAsync("username"),
                password = await SecureStorage.GetAsync("password"),
            };

            if (IsValid && user.email == Email && user.username != null && user.password != null) {
                
                await Shell.Current.DisplayAlert("Recuperación exitosa", $"Usuario: {user.username} \nPassword: {user.password}", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else {
                
                await Shell.Current.DisplayAlert("Error", $"No existe el usuario para el email: {user.email}", "OK");
            }
            
            

        }
        catch (Exception ex) {
            await Shell.Current.DisplayAlert("Error", $"{ex}", "OK");
        }


        
    }

    [RelayCommand]
    private async Task NavigateToRegister() {
        /* Metodo para viajar al RecoverPage */

        await Shell.Current.GoToAsync("RegisterPage");
    }

    // Propiedad booleana para validar el Entry
    private bool IsValid 
        => !string.IsNullOrWhiteSpace(Email);

}
