using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiseSync.Logic.Services
{
    public interface IRemoteDatabaseService
    {
        bool GetDatabaseStatus(string connectionString);
        Task SaveManySupplies(string connectionString, string databasename, IEnumerable<Supply> supplies);
    }
}
