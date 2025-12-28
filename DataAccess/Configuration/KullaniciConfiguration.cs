using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class KullaniciConfiguration : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.ToTable("tbl_kullanicilar").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.Email).HasColumnName("a_email").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Adi).HasColumnName("a_adi").HasColumnType("nvarchar(100)");
            builder.Property(x => x.SifreHash).HasColumnName("a_sifreHash").HasColumnType("nvarchar(500)");
            builder.Property(x => x.GoogleId).HasColumnName("a_GoogleId").HasColumnType("nvarchar(100)");
            builder.Property(x => x.Rol).HasColumnName("a_rol").HasColumnType("nvarchar(50)");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }
}
