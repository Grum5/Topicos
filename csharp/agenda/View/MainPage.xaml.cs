
namespace agenda.View;

using Data;
using agenda.ViewModel;

public partial class MainPage : ContentPage {

    private readonly DatabaseManager _db_controler;

	public MainPage(DatabaseManager db_controler) {

		InitializeComponent();

        _db_controler = db_controler;
	}

    public void IrListaContactos(object sender, EventArgs e) {
        
        // Crear el View
        var lista_contactos_page = new ContactosPage(_db_controler);

        // Crear el ViewModel y pasarle la instancia de la base de datos
        var lista_contactos_viewmodel = new ContactosViewModel(_db_controler);
            
        // Relacionar el ViewModel con el View
        lista_contactos_page.BindingContext = lista_contactos_viewmodel;

        // Navegar al View
        Navigation.PushAsync(lista_contactos_page);
    }

    public void IrCrearContacto(object sender, EventArgs e) {
        
        // Crear el ViewModel y pasarle la instancia de la base de datos
        var crear_contacto_viewmodel = new CrearContactoViewModel(_db_controler);
            
        // Crear el View
        var crear_contacto_page = new CrearContactoPage();

        // Relacionar el ViewModel con el View
        crear_contacto_page.BindingContext = crear_contacto_viewmodel;
        
        // Navegar al View
        Navigation.PushAsync(crear_contacto_page);
    }

    public void IrConfiguracion(object sender, EventArgs e) {
        
        var config_page = new ConfiguracionPage();
        
        Navigation.PushAsync(config_page);
    }
}
