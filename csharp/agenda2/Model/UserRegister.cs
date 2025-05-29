
namespace agenda2.Model;

public class UserRegister {
    /*
     * Modelo para convertir a JSON
     * - Se usa para registrar un usuario nuevo mediante un JSON
     */

    public string? usuario { get; set; }
    public string? clave { get; set; }
    public string? email { get; set; }
    public int? activo { get; set; } = 1;
}
