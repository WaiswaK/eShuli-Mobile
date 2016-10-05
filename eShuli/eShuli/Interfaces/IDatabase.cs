using SQLite.Net;
using System.Threading.Tasks;

namespace eShuli.Interfaces
{
    public interface IDatabase
    {
        Task InitializeDatabase();
        SQLiteConnection GetConnection();
    }
}
