
namespace agenda.ViewModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using Data;
using System.Collections.ObjectModel;

internal partial class ContactosViewModel : ObservableObject {

    [ObservableProperty]
    private ObservableCollection<Contacto> contactos = new();

    private readonly DatabaseManager _db_controler;

    public ContactosViewModel(DatabaseManager db_controler) {
        
        _db_controler = db_controler;

        _ = CargarContactoAsync();
    }

    public async Task CargarContactoAsync() {

        var listaContactos = await _db_controler.ObtenerContactosAsync();

        Contactos.Clear();

        foreach (var contacto in listaContactos) {
            Contactos.Add(contacto);
        }
    }

    [RelayCommand]
    public async Task Vaciar() {
        await _db_controler.VaciarContactos();

        await CargarContactoAsync();
    }
}
