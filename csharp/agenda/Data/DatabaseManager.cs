
using SQLite;
using agenda.Model;

namespace agenda.Data;

public class DatabaseManager {

    private const string DB_NAME = "contactos.db";
    private readonly SQLiteAsyncConnection _connection;
    
    public DatabaseManager() {
        /* Constructor */

        // Almacenar el path donde se almacenara la base de datos
        string path = Path.Combine(FileSystem.AppDataDirectory, DB_NAME);

        // Crear la nueva instancia de la base de datos y pasar el path del archivo
        _connection = new SQLiteAsyncConnection(path);

        // Si no existe la tabla se creara
        // Se crea una variable temporal para poder mandar llamar la funcion de manera asyncrona sin detener el hilo
        _ = CrearTablasAsync();
    }

    private async Task CrearTablasAsync() {
        /* 
         * Metodo que crea una tabla con los parametros de "Contacto"
         *  - Crea la tabla de manera asyncrona
         */

        // Esperar a que se cree la tabla
        await _connection.CreateTableAsync<Contacto>();
    }
    
    public async Task<bool> GuardarContactoAsync(Contacto contacto) {
        
        try {
            await _connection.InsertAsync(contacto);
            return true;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error al guardar el contacto: {ex.Message}");
            return false;
        }
    }

    public async Task<List<Contacto>> ObtenerContactosAsync() {

        try {
            return await _connection.Table<Contacto>().ToListAsync();
        }
        catch (Exception ex) {
            Console.WriteLine($"Error al obtener los contactos : {ex.Message}");
            return new List<Contacto>();
        }
    }

    public async Task VaciarContactos() {

        try {
            await _connection.DeleteAllAsync<Contacto>();
        }
        catch (Exception ex) {
            Console.WriteLine($"Error vaciando los contactos: {ex.Message}");
        }
    }

}
