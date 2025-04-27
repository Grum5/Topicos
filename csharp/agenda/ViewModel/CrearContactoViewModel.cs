
namespace agenda.ViewModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data;
using Model;

internal partial class CrearContactoViewModel : ObservableObject {

    [ObservableProperty]
    private string nombre;

    [ObservableProperty]
    private string telefono;

    [ObservableProperty]
    private string correo;

    [ObservableProperty]
    private string direccion;
    
    private readonly DatabaseManager db_manager;

    public CrearContactoViewModel(DatabaseManager db_manager) {

        this.db_manager = db_manager;
    }

    [RelayCommand]
    public async Task Guardar() {

        if ( !(string.IsNullOrWhiteSpace(Nombre) ||
            string.IsNullOrWhiteSpace(Telefono) ||
            string.IsNullOrWhiteSpace(Correo) ||
            string.IsNullOrWhiteSpace(Direccion))) {

            await db_manager.GuardarContactoAsync(new Contacto {
                
                Nombre = Nombre,
                Telefono = Telefono,
                Correo = Correo,
                Direccion = Direccion
            });

            Nombre = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
            Direccion = string.Empty;
        }
    }
}
