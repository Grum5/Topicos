/* Interface */ 

using System.Threading.Tasks;

namespace dbAccessAvalonia.backend {

    public interface InterfaceDB {
        
        Task ConnectAsync();             
        Task CreateTableAsync(string tableName);
        // void SetTable(string table);
        Task InsertDataAsync(string nombre, string carrera);
        Task ReadDataAsync();
    }
}
