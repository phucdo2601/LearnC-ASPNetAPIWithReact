using Microsoft.EntityFrameworkCore;

namespace MyWebAPIApp.Data
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
                
        }
        // tao DbSet de tao bang trong DB
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set;}

        public DbSet<Loai> Loais { get; set;}
        #endregion
    }
}
