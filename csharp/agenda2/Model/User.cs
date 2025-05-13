
namespace Model;

public class User {
    /*
     * Modelo para la obtencion de los datos del usuario
     * - Se podria escalar para convertirlo a un JSON
     */

    public string? email { get; set; }
    public required string username { get; set; }
    public required string password { get; set; }
}
