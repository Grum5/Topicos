namespace agenda2.ViewModel; 

using Model;
using Services.LocalStorage;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

internal partial class AgendaViewModel : ObservableObject {

    [ObservableProperty]
    private ObservableCollection<Contact> contacts = new();

    [ObservableProperty]
    private string? name;
    [ObservableProperty]
    private string? phone;
    [ObservableProperty]
    private string? email;

    private readonly DatabaseManager _db_controller;

    public AgendaViewModel(DatabaseManager db_controller) {

        _db_controller = db_controller;

        // _ = _db_controller.VaciarContactos();
        // Cargar los contactos en cuanto se inicie la ventana
        _ = LoadContacts();
    }

    public async Task LoadContacts() {

        var contactsList = await _db_controller.ObtenerContactosAsync();

        Contacts.Clear();

        foreach (var contact in contactsList) {
            Contacts.Add(contact);
        }
    }

    [RelayCommand]
    private async Task DeleteContact(Contact contact) {

        bool confirm = await Shell.Current.DisplayAlert(
            "Confirmar",
            $"¿Eliminar a {contact.Name}?",
            "Sí", "No");

        if (confirm)
        {
            await _db_controller.BorrarContactoAsync(contact.Id);
            
            // Eliminar de la colección
            Contacts.Remove(contact);
            
            // Opcional: Mostrar notificación
            await Shell.Current.DisplayAlert("Éxito", "Contacto eliminado", "OK");
        }
    }

    [RelayCommand]
    private async Task SaveContact() {
        
        try {
            if ( !(String.IsNullOrWhiteSpace(Name) && String.IsNullOrWhiteSpace(Phone) && String.IsNullOrWhiteSpace(Email))) {

                var _contact = new Contact {
                    Name = this.Name,
                    Phone = this.Phone,
                    Email = this.Email
                };

                await _db_controller.GuardarContactoAsync(_contact);
                await LoadContacts();
            }
        }
        catch (Exception ex) {
            await Shell.Current.DisplayAlert("Error", $"{ex}", "OK");
        }
    }

    [RelayCommand]
    private async Task Logout() {
        
        bool confirm = await Shell.Current.DisplayAlert("Cerrar sesión", "¿Desea salir?", "Si", "Cancel");

        if (confirm) {
            
            SecureStorage.Remove("IsLoggedIn");

            await Shell.Current.GoToAsync("//LoginPage");
        }
        
    }

}

