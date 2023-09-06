using System;

namespace TeamCapacityBalancing.Services.Postgres_connection
{
    public class DataBaseConnection
    {
        private static DataBaseConnection? _instance;
        private static readonly object _lock = new object();

        private const string Host = "localhost";
        private const string User = "postgres";
<<<<<<< HEAD
        private const string DBname = "Jira";
        private const string Password = "ciocanitoarea";
=======
        private const string DBname = "postgres";
        private const string Password = "123456";
>>>>>>> 017329394535519cecafbad4da09cd6c864e474d
        private const string Port = "5432";

        private string connectionString = String.Format(
                    "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);

        private DataBaseConnection()
        {
        }
        public static DataBaseConnection GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DataBaseConnection();
                }
                return _instance;
            }
        }
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
