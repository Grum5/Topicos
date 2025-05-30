
namespace agenda2.Model;

public class UserAuth {
    /*
     * Modelo para convertir a JSON
     * - Se usa para mandar a aunteticar un usuario a una API
     */

    public string? usuario { get; set; }
    public string? clave { get; set; }
}
