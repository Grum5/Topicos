namespace not_push;

using System;
using Microsoft.Data.SqlClient;

class Program {
    
    static void Main() {

        string connStr = "Server=localhost,1433;Database=master;User Id=sa;Password=MANZANA3;TrustServerCertificate=True;";

        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                Console.WriteLine("✅ Conexión exitosa a la base de datos");

                string query = "SELECT name FROM sys.databases";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("📌 Bases de datos disponibles:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"- {reader.GetString(0)}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }

    }
}
