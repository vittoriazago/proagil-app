using Microsoft.EntityFrameworkCore;

namespace ProAgil.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                : base(options)
        {
            
        }
    }
}