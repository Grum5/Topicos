
namespace agenda2.Views.Login;

public partial class RegisterPage : ContentPage {

    public RegisterPage() {

        InitializeComponent();
        BindingContext = new ViewModel.RegisterViewModel();
    }
}
