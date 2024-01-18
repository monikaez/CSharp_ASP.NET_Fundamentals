using System.ComponentModel.DataAnnotations;

namespace Chat.Models.Chat
{
    public class MessageViewModel
    {
        [Required]
        public string Sender { get; set; } = null!;
        [Required]
        [MaxLength(256)]
        public string MessageText { get; set; } = null!;
    }
}
