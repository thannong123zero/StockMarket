using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyDTO>
    {
        public void Configure(EntityTypeBuilder<CompanyDTO> builder)
        {
            builder.ToTable("Table_Companies");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
        }
    }
}
