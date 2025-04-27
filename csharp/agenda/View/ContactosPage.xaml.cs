
namespace agenda.View;

using Data;

public partial class ContactosPage : ContentPage {
    
    public ContactosPage(DatabaseManager _dbService) {

		InitializeComponent();
           
    }

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e) {

        if (e.CurrentSelection.FirstOrDefault() is Model.Contacto contactoSeleccionado) {

            ((CollectionView)sender).SelectedItem = null;

            await Navigation.PushAsync(new DetalleContactoPage(contactoSeleccionado));
        }
    }
}
