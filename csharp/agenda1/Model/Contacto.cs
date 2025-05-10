
using SQLite;

namespace agenda.Model;

[Table("contacto")]
public class Contacto {

    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("telefono")]
    public string Telefono { get; set; }

    [Column("correo")]
    public string Correo { get; set; }

    [Column("direccion")]
    public string Direccion { get; set; }
}
