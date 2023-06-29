using Microsoft.EntityFrameworkCore;

namespace Wondy.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}