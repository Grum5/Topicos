
using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dbAccessAvalonia.backend {

    public class MySqlManager : InterfaceDB {
        
        private string Server { get; }
        private string Port { get; }
        private string Database { get; }
        private string User { get; }
        private string Password;

        private string connMySQL;

        private MySqlConnection conn;

        private bool connStatus = false;

        public MySqlManager(string server = "localhost", string port = "3306", string database = "mysql", string user = "test", string password = "1234") {
            /* Constructor */

            Server = server;
            Port = port;
            Database = database;
            User = user;
            Password = password;

            // Cadena de conexion
            connMySQL = $"server={Server};port={Port};database={Database};user={User};password={Password};";

            // Se crea una instancia de conexion a la base de datos
            conn = new MySqlConnection(connMySQL);
        }

        public async Task ConnectAsync() {
            /* Metodo asincrono para conectarse a la base de datos */

            try {
                
                // Verificar si ya se conecto a la base de datos
                if (!connStatus) {

                    await conn.OpenAsync();
                    connStatus = true;
                    Console.WriteLine("Se conecto a la base de datos MySql");
                }
                
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

        }

        public async Task CreateTableAsync(string tableName = "usuarios") {
 
            try {
                
                // Si no esta abierta la conexion conectarse
                if (!connStatus) {
                    await ConnectAsync();
                    Console.WriteLine("Conectado a la base de datos");
                }

                // Crear Query para realizar solicitud
                string query = $"CREATE TABLE IF NOT EXISTS {tableName} " +
                    "(id INT AUTO_INCREMENT PRIMARY KEY," + 
                    " nombre VARCHAR(100)," +
                    " carrera VARCHAR(100)" +
                    ");";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                await cmd.ExecuteNonQueryAsync();
                Console.WriteLine("Tabla Creada");
            }
            catch (Exception ex){
                Console.WriteLine($"Error al crear la tabla: {ex.Message}");
            }
        }

        public async Task InsertDataAsync(string nombre, string carrera) {
            
            try {
                if(!connStatus) {
                    await ConnectAsync();
                    Console.WriteLine("Conectado a la base de datos");
                }

                // Crear Query para realizar solicitud
                string query = $"INSERT INTO ";

            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
        public async Task ReadDataAsync() {}
    }
}
