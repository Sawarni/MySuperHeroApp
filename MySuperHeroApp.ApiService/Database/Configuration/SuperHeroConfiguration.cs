using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySuperHeroApp.ApiService.Model;

namespace MySuperHeroApp.ApiService.Database.Configuration
{
    public class SuperHeroConfiguration : IEntityTypeConfiguration<SuperHero>
    {
        public void Configure(EntityTypeBuilder<SuperHero> builder)
        {
            builder.ToTable("SuperHeroes");

            builder.HasKey(sh => sh.Id);
            builder.Property(sh => sh.Id).IsRequired();
            builder.Property(sh => sh.Name).IsRequired();

            builder.OwnsOne(sh => sh.PowerStats, ps =>
            {
                ps.Property(p => p.Intelligence).HasColumnName("Intelligence").IsRequired(false);
                ps.Property(p => p.Strength).HasColumnName("Strength").IsRequired(false);
                ps.Property(p => p.Speed).HasColumnName("Speed").IsRequired(false);
                ps.Property(p => p.Durability).HasColumnName("Durability").IsRequired(false);
                ps.Property(p => p.Power).HasColumnName("Power").IsRequired(false);
                ps.Property(p => p.Combat).HasColumnName("Combat").IsRequired(false);
            });

            builder.OwnsOne(sh => sh.Biography, bio =>
            {
                bio.Property(b => b.FullName).HasColumnName("FullName").IsRequired(false);
                bio.Property(b => b.AlterEgos).HasColumnName("AlterEgos").IsRequired(false);
                bio.Property(b => b.PlaceOfBirth).HasColumnName("PlaceOfBirth").IsRequired(false);
                bio.Property(b => b.FirstAppearance).HasColumnName("FirstAppearance").IsRequired(false);
                bio.Property(b => b.Publisher).HasColumnName("Publisher").IsRequired(false);
                bio.Property(b => b.Alignment).HasColumnName("Alignment").IsRequired(false);
                bio.Property(b => b.Aliases)
                                .HasConversion(
                                    v => string.Join("~", v), // Serialize List<string> to a comma-separated string
                                     v => v.Split("~", StringSplitOptions.RemoveEmptyEntries).ToList() // Deserialize back to List<string>
        )
        .HasColumnName("Aliases").IsRequired(false);
            });

            builder.OwnsOne(sh => sh.Appearance, app =>
            {
                app.Property(a => a.Gender).HasColumnName("Gender").IsRequired(false);
                app.Property(a => a.Race).HasColumnName("Race").IsRequired(false);
                app.Property(a => a.Height).HasConversion(
                     height => string.Join("~", height), // Serialize List<string> to a comma-separated string,
                     height => height.Split("~", StringSplitOptions.RemoveEmptyEntries).ToList() // Deserialize back to List<string>
                    ).HasColumnName("Height").IsRequired(false);

                
                app.Property(a => a.Weight).HasConversion(
                
                    weight => string.Join("~", weight), // Serialize List<string> to a comma-separated string,
                     weight => weight.Split("~", StringSplitOptions.RemoveEmptyEntries).ToList() // Deserialize back to List<string>).HasColumnName("Weight");

                ).HasColumnName("Weight").IsRequired(false);
                app.Property(a => a.EyeColor).HasColumnName("EyeColor").IsRequired(false);
                app.Property(a => a.HairColor).HasColumnName("HairColor").IsRequired(false);
            });

            builder.OwnsOne(sh => sh.Work, work =>
            {
                work.Property(w => w.Occupation).HasColumnName("Occupation").IsRequired(false);
                work.Property(w => w.BaseOfOperation).HasColumnName("BaseOfOperation").IsRequired(false);
            });

            builder.OwnsOne(sh => sh.Connections, conn =>
            {
                conn.Property(c => c.GroupAffiliation).HasColumnName("GroupAffiliation").IsRequired(false);
                conn.Property(c => c.Relatives).HasColumnName("Relatives").IsRequired(false);
            });

            builder.OwnsOne(sh => sh.Image, img =>
            {
                img.Property(i => i.Url).HasColumnName("ImageUrl").IsRequired(false);
               
            });


        }
    }
}
