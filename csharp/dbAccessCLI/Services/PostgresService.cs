using Npgsql;
using dbAccessCLI.Models;

namespace dbAccessCLI.Services;

public class PostgresService : IBaseService {

    private readonly string connectionString = "Host=localhost;Username=alumnos;Password=1234;";

    public async Task InicializarAsync() {

    var systemConnection = new NpgsqlConnection("Host=localhost;Username=alumnos;Password=1234;Database=postgres;");
    await systemConnection.OpenAsync();

    var checkDb = new NpgsqlCommand("SELECT 1 FROM pg_database WHERE datname = 'alumnosdb'", systemConnection);
    var exists = await checkDb.ExecuteScalarAsync();

    if (exists == null) {

        var createDb = new NpgsqlCommand("CREATE DATABASE alumnosdb", systemConnection);
        await createDb.ExecuteNonQueryAsync();
    }

    await systemConnection.CloseAsync();

    var userDbConnection = new NpgsqlConnection("Host=localhost;Username=alumnos;Password=1234;Database=alumnosdb;");
    await userDbConnection.OpenAsync();

    var createTable = """
        CREATE TABLE IF NOT EXISTS alumnos (
            matricula VARCHAR(20) PRIMARY KEY,
            nombre VARCHAR(100),
            inscrito BOOLEAN,
            semestre INTEGER,
            carrera VARCHAR(100)
        );
    """;

    var tableCmd = new NpgsqlCommand(createTable, userDbConnection);
    await tableCmd.ExecuteNonQueryAsync();

    await userDbConnection.CloseAsync();
    }

    public async Task AgregarAlumnoAsync(Alumno alumno) {

        using var connection = new NpgsqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = """
            INSERT INTO alumnos (matricula, nombre, inscrito, semestre, carrera)
            VALUES (@matricula, @nombre, @inscrito, @semestre, @carrera);
        """;

        await using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@matricula", alumno.Matricula);
        cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
        cmd.Parameters.AddWithValue("@inscrito", alumno.Inscrito);
        cmd.Parameters.AddWithValue("@semestre", alumno.Semestre);
        cmd.Parameters.AddWithValue("@carrera", alumno.Carrera);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<List<Alumno>> LeerAlumnosAsync() {

        using var connection = new NpgsqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = "SELECT matricula, nombre, inscrito, semestre, carrera FROM alumnos;";
        await using var cmd = new NpgsqlCommand(query, connection);

        var reader = await cmd.ExecuteReaderAsync();
        var alumnos = new List<Alumno>();

        while (await reader.ReadAsync()) {
            alumnos.Add(new Alumno {

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

        using var connection = new NpgsqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = """
            UPDATE alumnos
            SET nombre = @nombre, inscrito = @inscrito, semestre = @semestre, carrera = @carrera
            WHERE matricula = @matricula;
        """;

        await using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", nuevoAlumno.Nombre);
        cmd.Parameters.AddWithValue("@inscrito", nuevoAlumno.Inscrito);
        cmd.Parameters.AddWithValue("@semestre", nuevoAlumno.Semestre);
        cmd.Parameters.AddWithValue("@carrera", nuevoAlumno.Carrera);
        cmd.Parameters.AddWithValue("@matricula", matricula);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task EliminarAlumnoAsync(string matricula) {

        using var connection = new NpgsqlConnection(connectionString + "Database=alumnosdb;");
        await connection.OpenAsync();

        var query = "DELETE FROM alumnos WHERE matricula = @matricula;";
        await using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@matricula", matricula);
        await cmd.ExecuteNonQueryAsync();
    }
}
