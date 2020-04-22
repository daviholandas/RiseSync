using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RiseSync.Logic.Services
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
       

        public bool GetStatusConnectDatabase(string connectionString)
        {
            using(var connect = new MySqlConnection( connectionString))
            {
                try
                {
                    connect.Open();
                    if (connect.State == ConnectionState.Open && connect.Database != string.Empty ) return true;
                    return false;
                }
                catch(Exception ex)
                {
                    connect.CloseAsync();
                    return false;
                }
            }
        }

        public async Task<IEnumerable<Supply>> GetAllSupplies(string connectionString, string database)
        {
            using (var connect = new MySqlConnection(connectionString))
            {
                await connect.OpenAsync();
                var supplies = await connect.QueryAsync<Supply>($"SELECT IN_ID, IN_NOM,IN_COD, IN_VALOR,IN_SUBGR," +
                    $"categoria.SG_NOM as Category FROM {database}.si_insu as insumos inner join {database}.si_s_gru as categoria on insumos.IN_SUBGR = categoria.SG_COD;");

                return supplies;

            }
        }
    }
}
