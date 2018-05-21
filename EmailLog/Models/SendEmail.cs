using System.ComponentModel.DataAnnotations;

namespace EmailLog.Models
{
    public class SendEmail
    {
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
