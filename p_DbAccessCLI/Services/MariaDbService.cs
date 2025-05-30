using MySqlConnector;
using dbAccessCLI.Models;

namespace dbAccessCLI.Services;

public class MariaDbService : IBaseService {

    private readonly string connectionString = "Server=localhost;User ID=alumnos;Password=1234;";       

    public async Task InicializarAsync() {
        
    using var connection = new MySqlConnection(connectionString);
    await connection.OpenAsync();

    var createDbCmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS alumnosdb", connection);
    await createDbCmd.ExecuteNonQueryAsync();

    await connection.CloseAsync();

    var dbConnectionString = connectionString + "Database=alumnosdb;";
    using var dbConnection = new MySqlConnection(dbConnectionString);
    await dbConnection.OpenAsync();

    var createTable = """
        CREATE TABLE IF NOT EXISTS alumnos (
            id INT AUTO_INCREMENT PRIMARY KEY,
            matricula VARCHAR(20) UNIQUE NOT NULL,
            nombre VARCHAR(100),
            inscrito BOOLEAN,
            semestre INT,
            carrera VARCHAR(100)
        );
    """;

    var createTableCmd = new MySqlCommand(createTable, dbConnection);
    await createTableCmd.ExecuteNonQueryAsync();
    }

    public async Task AgregarAlumnoAsync(Alumno alumno) {

        using var connection = new MySqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = """
            INSERT INTO alumnos (matricula, nombre, inscrito, semestre, carrera)
            VALUES (@matricula, @nombre, @inscrito, @semestre, @carrera);
        """;

        await using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@matricula", alumno.Matricula);
        cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
        cmd.Parameters.AddWithValue("@inscrito", alumno.Inscrito);
        cmd.Parameters.AddWithValue("@semestre", alumno.Semestre);
        cmd.Parameters.AddWithValue("@carrera", alumno.Carrera);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<List<Alumno>> LeerAlumnosAsync() {

        using var connection = new MySqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = "SELECT matricula, nombre, inscrito, semestre, carrera FROM alumnos;";
        await using var cmd = new MySqlCommand(query, connection);

        var reader = await cmd.ExecuteReaderAsync();
        var alumnos = new List<Alumno>();

        while (await reader.ReadAsync())
        {
            alumnos.Add(new Alumno
            {
                Matricula = reader.GetString(0),
                Nombre = reader.GetString(1),
                Inscrito = reader.GetBoolean(2),
                Semestre = reader.GetInt32(3),
                Carrera = reader.GetString(4),
            });
        }

        return alumnos;
    }

    public async Task EditarAlumnoAsync(string matricula, Alumno nuevoAlumno) {
        
        using var connection = new MySqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = """
            UPDATE alumnos
            SET nombre = @nombre, inscrito = @inscrito, semestre = @semestre, carrera = @carrera
            WHERE matricula = @matricula;
        """;

        await using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", nuevoAlumno.Nombre);
        cmd.Parameters.AddWithValue("@inscrito", nuevoAlumno.Inscrito);
        cmd.Parameters.AddWithValue("@semestre", nuevoAlumno.Semestre);
        cmd.Parameters.AddWithValue("@carrera", nuevoAlumno.Carrera);
        cmd.Parameters.AddWithValue("@matricula", matricula);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task EliminarAlumnoAsync(string matricula) {
        
        using var connection = new MySqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = "DELETE FROM alumnos WHERE matricula = @matricula;";
        await using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@matricula", matricula);
        await cmd.ExecuteNonQueryAsync();
    }
}
