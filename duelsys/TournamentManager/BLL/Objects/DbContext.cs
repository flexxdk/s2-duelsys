namespace DAL
{
    public class DbContext
    {
        public string DbConnectionString { get; private set; }

        private readonly string DefaultConnectionString = "Server=studmysql01.fhict.local;Uid=dbi488027;Database=dbi488027;Pwd=KVKwg8LSE2QTK88o";

        public DbContext(string? conString = null)
        {
            DbConnectionString = conString ?? DefaultConnectionString;
        }
    }
}
