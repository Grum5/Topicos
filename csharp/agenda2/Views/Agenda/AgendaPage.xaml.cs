namespace agenda2.Views.Agenda;

public partial class AgendaPage : ContentPage {

    public AgendaPage () {

        InitializeComponent();
        BindingContext = new ViewModel.AgendaViewModel();
    }
}
