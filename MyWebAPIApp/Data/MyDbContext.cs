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

        public DbSet<DonHang> DonHangs { get; set;}

        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set;}
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);

                // set rang buoc cho mot truong du lieu trong entity
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);   
            });

            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(e => new { e.MaDh, e.MaHh });

                // cai dat rang buoc cho bang ChiTietDonHang voi bang DonHang
                e.HasOne(e => e.DonHang)
                    .WithMany(e => e.DonHangChiTiets)
                    .HasForeignKey(e => e.MaDh)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                // cai dat rang buoc cho bang ChiTietDonHang voi bang HangHoa
                e.HasOne(e => e.HangHoa)
                    .WithMany(e => e.DonHangChiTiets)
                    .HasForeignKey(e => e.MaHh)
                    .HasConstraintName("FK_ChiTietDonHang_HangHoa");

            });
        }
    }
}
