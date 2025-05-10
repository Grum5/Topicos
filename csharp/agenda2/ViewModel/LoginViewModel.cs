

namespace agenda2.ViewModel; 

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

// DEBUGGING 
// using CommunityToolkit.Maui.Alerts;

internal partial class LoginViewModel : ObservableObject {

    [ObservableProperty]
    private string? username;

    [ObservableProperty]
    private string? password;


    [RelayCommand]
    private async Task Login() {

        if (IsValid) {
            await Shell.Current.DisplayAlert("Debug", $"Username: {Username}, Password: {Password}", "OK");
        }
        else {
            await Shell.Current.DisplayAlert("Usuario incorrecto", "No le sabes pa", "OK");
        }
    }

    [RelayCommand]
    private async Task NavigateToRegister() {
        
        await Shell.Current.GoToAsync("RegisterPage");
    }

    // Validar si el usuario es el correcto
    private bool IsValid 
        => !string.IsNullOrWhiteSpace(Username)
        && !string.IsNullOrWhiteSpace(Password)
        && Username == "admin"
        && Password == "1234";
}

