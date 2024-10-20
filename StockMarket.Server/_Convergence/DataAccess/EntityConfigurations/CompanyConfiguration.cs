using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Server._Convergence.DataAccess.DTOs;

namespace StockMarket.Server._Convergence.DataAccess.EntityConfigurations
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
