using System;

namespace DnDBuilderLinux.Database
{
    public class DatabaseException: Exception
    {
        public DatabaseException(string message, Exception innerException): base(message, innerException) { }

        public DatabaseException(string message): base(message) { }
    }
}