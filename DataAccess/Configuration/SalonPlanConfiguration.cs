using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class SalonPlanConfiguration : IEntityTypeConfiguration<SalonPlan>
    {
        public void Configure(EntityTypeBuilder<SalonPlan> builder)
        {
            builder.ToTable("tbl_salon_plan").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("a_id").HasColumnType("int");
            builder.Property(x => x.KullaniciId).HasColumnName("a_kullanici_id").HasColumnType("int");
            builder.Property(x => x.MaxSalonSayisi).HasColumnName("a_max_salon_sayisi").HasColumnType("int");
            builder.Property(x => x.AktifSalonSayisi).HasColumnName("a_aktif_salon_sayisi").HasColumnType("int");
            builder.Property(x => x.PlanAdi).HasColumnName("a_plan_adi").HasColumnType("nvarchar(100)");
            builder.Property(x => x.CDate).HasColumnName("a_cdate").HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(x => x.MDate).HasColumnName("a_mdate").HasColumnType("datetime").HasDefaultValueSql("(datefromparts((1900),(1),(1)))");
        }
    }


}
