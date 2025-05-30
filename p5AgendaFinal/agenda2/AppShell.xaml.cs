namespace agenda2;

public partial class AppShell : Shell
{

	public AppShell()
	{
		InitializeComponent();

        SetRoutes();
	}

    private void SetRoutes() {

        Routing.RegisterRoute(nameof(Views.Login.LoginPage), typeof(Views.Login.LoginPage));
        Routing.RegisterRoute(nameof(Views.Login.RegisterPage), typeof(Views.Login.RegisterPage));
        Routing.RegisterRoute(nameof(Views.Login.RecoverPage), typeof(Views.Login.RecoverPage));
    }
}
