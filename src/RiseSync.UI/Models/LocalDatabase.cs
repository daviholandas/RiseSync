using System;
using System.Collections.Generic;
using System.Text;

namespace RiseSync.UI.Models
{
    public class LocalDatabase
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string GenerateConnectionString() => $"Server={Server};Port={Port};Database={Database};User={User};Password={Password};";

    }
}
