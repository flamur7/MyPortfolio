using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class FrontEndTechnology
    {
        [Key]
        public int FrontEndTechnologyId { get; set; }

        [Required]
        [Display(Name = "Front-End        ")]
        public string FrontEndName { get; set; }

        public virtual ICollection<ProjectMade> ProjectMades { get; set; }
        public virtual ICollection<Collaborators> Collaboratorss { get; set; }
    }
}
