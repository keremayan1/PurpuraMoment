using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class QRKodConfiguration : IEntityTypeConfiguration<QRKod>
    {
        public void Configure(EntityTypeBuilder<QRKod> builder)
        {
            builder.ToTable("tbl_qr_kodlar").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.SalonBolumId).HasColumnName("a_salon_bolum_id").HasColumnType("int");
            builder.Property(x => x.QrData).HasColumnName("a_qr_data").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }


}
