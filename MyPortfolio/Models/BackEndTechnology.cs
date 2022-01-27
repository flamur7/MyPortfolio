using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class BackEndTechnology
    {
        [Key]
        public int BackEndTechnologyId { get; set; }

        [Display(Name = "Back-End")]
        public string BackEndTechnologyName { get; set; }

        public virtual ICollection<ProjectMade> ProjectMades { get; set; }
        public virtual ICollection<Collaborators> Collaboratorss { get; set; }
    }
}
