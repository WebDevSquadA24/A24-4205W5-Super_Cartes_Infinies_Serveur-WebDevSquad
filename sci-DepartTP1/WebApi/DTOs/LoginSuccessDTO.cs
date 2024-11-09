using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class LoginSuccessDTO
    {
        [Required]
        public string Token { get; set; } = "";
        [Required]
        public string Username { get; set; } = "";
        [Required]
        public int PlayerId { get; set; }
        
        [Required]
        public double PlayerMoney { get; set; }
    }
}
