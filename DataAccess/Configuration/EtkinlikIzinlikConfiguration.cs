using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class EtkinlikIzinlikConfiguration : IEntityTypeConfiguration<EtkinlikIzin>
    {
        public void Configure(EntityTypeBuilder<EtkinlikIzin> builder)
        {
            builder.ToTable("tbl_etkinlik_izinler").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.EtkinlikId).HasColumnName("a_etkinlik_id").HasColumnType("int");
            builder.Property(x => x.KullaniciId).HasColumnName("a_kullanici_id").HasColumnType("int");
            builder.Property(x => x.Goruntuleme).HasColumnName("a_goruntuleme").HasColumnType("bit");
            builder.Property(x => x.Indirme).HasColumnName("a_indirme").HasColumnType("bit");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }
}
