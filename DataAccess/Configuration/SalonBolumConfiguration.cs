using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class SalonBolumConfiguration : IEntityTypeConfiguration<SalonBolum>
    {
        public void Configure(EntityTypeBuilder<SalonBolum> builder)
        {
            builder.ToTable("tbl_salon_bolumleri").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.SalonId).HasColumnName("a_salon_id").HasColumnType("int");
            builder.Property(x => x.Adi).HasColumnName("a_adi").HasColumnType("nvarchar(50)");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }


}
