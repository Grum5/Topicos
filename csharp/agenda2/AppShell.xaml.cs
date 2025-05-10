namespace agenda2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.Login.LoginPage), typeof(Views.Login.LoginPage));
        Routing.RegisterRoute(nameof(Views.Login.RegisterPage), typeof(Views.Login.RegisterPage));

	}
}
