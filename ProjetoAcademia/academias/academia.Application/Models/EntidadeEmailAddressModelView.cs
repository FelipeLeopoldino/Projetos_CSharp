using System.ComponentModel.DataAnnotations;

namespace academia.Application.Models
{
    public class EntidadeEmailAddressModelView
    {
        [Required]
        public string? From { get; set; }

        [Required]
        public string? To { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Body { get; set; }
    }
}
