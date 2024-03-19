using Microsoft.EntityFrameworkCore;
using pruebaPuestoDGII.Models;

namespace pruebaPuestoDGII.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }
        public DbSet<Contribuyente> Contribuyente { get; set; }
        public DbSet<ComprobantesFiscales> ComprobantesFiscales { get; set; }
    }
}