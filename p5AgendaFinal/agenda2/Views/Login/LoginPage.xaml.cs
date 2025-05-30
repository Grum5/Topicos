
namespace agenda2.Views.Login;

public partial class LoginPage : ContentPage {

    public LoginPage() {

        InitializeComponent();
        BindingContext = new ViewModel.LoginViewModel(this.Navigation);
    }
}
