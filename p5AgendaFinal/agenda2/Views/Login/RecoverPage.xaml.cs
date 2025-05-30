
namespace agenda2.Views.Login;

public partial class RecoverPage : ContentPage {

    public RecoverPage() {

        InitializeComponent();
        BindingContext = new ViewModel.RecoverViewModel();
    }
}
