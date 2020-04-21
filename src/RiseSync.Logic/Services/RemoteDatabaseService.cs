using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiseSync.Logic.Services
{
    public class RemoteDatabaseService : IRemoteDatabaseService
    {
       
        public bool GetDatabaseStatus(string connectionString)
        {
            throw new NotImplementedException();
        }

        public async Task SaveManySupplies(string connectionString, string databasename, IEnumerable<Supply> supplies)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databasename).GetCollection<Supply>("supplies");

           await database.InsertManyAsync(supplies);
          
               
           
        }

       
    }
}
