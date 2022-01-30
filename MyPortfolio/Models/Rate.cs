using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }

        [Display(Name = "Select Project")]
        public int ProjectMadeId { get; set; }
        [ForeignKey("ProjectMadeId")]
        public virtual ProjectMade ProjectMade { get; set; }

        [Display(Name ="Comment")]
        public string CommentRate { get; set; }
    }
}
