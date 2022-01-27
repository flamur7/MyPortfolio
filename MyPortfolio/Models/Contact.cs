using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required, Display(Name ="Full Name")]
        public string ContactFullName { get; set; }

        [Required, Display(Name = "Subject")]
        public string ContactSubject { get; set; }

        [Required, Display(Name = "Email")]
        public string Email { get; set; }

        [Required, Display(Name = "Message")]
        public string Message { get; set; }

    }
}
