using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.ToTable("tbl_salonlar").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.KullaniciId).HasColumnName("a_kullaniciId").HasColumnType("int");
            builder.Property(x => x.SalonAdi).HasColumnName("a_salon").HasColumnType("nvarchar(100)");
            builder.Property(x => x.Adres).HasColumnName("a_adres").HasColumnType("nvarchar(255)");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }

}
