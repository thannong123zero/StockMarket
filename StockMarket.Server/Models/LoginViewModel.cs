using System.ComponentModel.DataAnnotations;

namespace StockMarket.Server.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}