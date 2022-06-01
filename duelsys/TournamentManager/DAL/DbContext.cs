using System.Text;

namespace DAL
{
    public class DbContext
    {
        public string DbConnectionString { get; private set; }

        public DbContext()
        {
            DbConnectionString = "Server=studmysql01.fhict.local;Uid=dbi488027;Database=dbi488027;Pwd=KVKwg8LSE2QTK88o";
        }

        public DbContext(string? server, string? uid, string? database, string? pwd)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Server=");
            builder.Append(server ?? "studmysql01.fhict.local");
            builder.Append(";Uid=");
            builder.Append(uid ?? "dbi488027");
            builder.Append(";Database=");
            builder.Append(database ?? "dbi488027");
            builder.Append(";Pwd=");
            builder.Append(pwd ?? "KVKwg8LSE2QTK88o");
            builder.Append(";");
            DbConnectionString = builder.ToString();
        }
    }
}
