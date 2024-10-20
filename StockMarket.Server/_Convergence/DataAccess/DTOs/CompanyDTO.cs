namespace StockMarket.Server._Convergence.DataAccess.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public ICollection<StockHistoryDTO> StockHistories { get; set; }
    }
}
