using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class MedyaConfiguration : IEntityTypeConfiguration<Medya>
    {
        public void Configure(EntityTypeBuilder<Medya> builder)
        {
            builder.ToTable("tbl_medya").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.EtkinlikId).HasColumnName("a_etkinlik_id").HasColumnType("int");
            builder.Property(x => x.DosyaUrl).HasColumnName("a_dosyaUrl").HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.DosyaTipi).HasColumnName("a_dosyaTipi").HasColumnType("tinyint");
            builder.Property(x => x.YukleyenMisafir).HasColumnName("a_yukleyenMisafir").HasColumnType("nchar(100)");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }
}
