
namespace agenda2.ViewModel; 

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

internal partial class RegisterViewModel : ObservableObject {

    [ObservableProperty]
    private string? username;

    [ObservableProperty]
    private string? password;

    [ObservableProperty]
    private string? confirmPassword;


    [RelayCommand]
    private async Task Register() {

        if (IsValid) {
            await Shell.Current.DisplayAlert("Debug", "Si es valido", "OK");
        }
        else {
            await Shell.Current.DisplayAlert("Error chulo", "No es valido", "OK");
        }
    }

    [RelayCommand]
    private async Task ReturnToLogin() {
        
        await Shell.Current.GoToAsync("..");
    }

    // Validar los campos
    private bool IsValid 
        => !string.IsNullOrWhiteSpace(Username)
        && !string.IsNullOrWhiteSpace(Password)
        && !string.IsNullOrWhiteSpace(ConfirmPassword)
        && Password.Length > 8
        && Password == ConfirmPassword;
            
}

