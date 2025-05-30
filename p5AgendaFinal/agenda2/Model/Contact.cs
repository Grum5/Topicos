
namespace agenda2.Model;

using SQLite;

[Table("contact")]
public class Contact {
    
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("nombre")]
    public string? Name { get; set; }

    [Column("telefono")]
    public string? Phone { get; set; }

    [Column("correo")]
    public string? Email { get; set; }

    [Column("direccion")]
    public string? Direction { get; set; }
}
