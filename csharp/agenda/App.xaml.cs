
namespace agenda;

using View;
using Data;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
        
        // Crear la instancia unica de la base de datos
        DatabaseManager db_controler = new DatabaseManager();

		return new Window(new NavigationPage(new View.MainPage(db_controler)));
	}
}
