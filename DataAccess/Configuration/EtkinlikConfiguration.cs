using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class EtkinlikConfiguration : IEntityTypeConfiguration<Etkinlik>
    {
        public void Configure(EntityTypeBuilder<Etkinlik> builder)
        {
            builder.ToTable("tbl_etkinlikler").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.SalonId).HasColumnName("a_salon_id").HasColumnType("int");
            builder.Property(x => x.SalonBolumId).HasColumnName("a_salon_bolum_id").HasColumnType("int");
            builder.Property(x => x.CiftAdi).HasColumnName("a_cift_adi").HasColumnType("nvarchar(100)");
            builder.Property(x => x.BaslangicZaman).HasColumnName("a_baslangic_zaman").HasColumnType("datetime");
            builder.Property(x => x.BitisZaman).HasColumnName("a_bitis_zaman").HasColumnType("datetime");
            builder.Property(x => x.Paylasim).HasColumnName("a_paylasim").HasColumnType("bit");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }

}
