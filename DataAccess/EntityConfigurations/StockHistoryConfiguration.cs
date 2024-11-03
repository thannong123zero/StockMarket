using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class StockHistoryConfiguration : IEntityTypeConfiguration<StockHistoryDTO>
    {
        public void Configure(EntityTypeBuilder<StockHistoryDTO> builder)
        {
            builder.ToTable("Table_StockHistories");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.HasOne(s => s.Company)
                .WithMany(c => c.StockHistories)
                .HasForeignKey(s => s.CompanyId);
        }
    }
}
