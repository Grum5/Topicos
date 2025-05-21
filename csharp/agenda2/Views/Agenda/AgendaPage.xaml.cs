namespace agenda2.Views.Agenda;

using Services.LocalStorage;

public partial class AgendaPage : ContentPage {

    public AgendaPage () {

        // Inyectamos el servicio de la base de datos
        DatabaseManager _db = new DatabaseManager();

        InitializeComponent();
        BindingContext = new ViewModel.AgendaViewModel(_db);
    }
}
