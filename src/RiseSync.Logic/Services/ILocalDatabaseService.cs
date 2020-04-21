﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiseSync.Logic.Services
{
    public interface ILocalDatabaseService
    {
        Task<IEnumerable<Supply>> GetAllSupplies(string connectionString);
        bool GetStatusConnectDatabase(string connectionString);
    }
}
