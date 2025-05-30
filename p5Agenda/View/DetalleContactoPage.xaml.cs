namespace agenda.View;

public partial class DetalleContactoPage : ContentPage
{
    public DetalleContactoPage(Model.Contacto contacto)
    {
        InitializeComponent();
        BindingContext = contacto; // Aquí ligamos el contacto que recibimos
    }
}
