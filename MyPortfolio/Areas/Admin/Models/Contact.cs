using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Subject { get; set; }
        public string Field { get; set; }

    }
}
