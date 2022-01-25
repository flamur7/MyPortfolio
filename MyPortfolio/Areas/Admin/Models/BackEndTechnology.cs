using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.Models
{
    public class BackEndTechnology
    {
        [Key]
        public int BackEndTechnologyId { get; set; }
        public string BackEndTechnologyName { get; set; }

        public virtual ICollection<ProjectMade> ProjectMades { get; set; }
        public virtual ICollection<Collaborators> Collaboratorss { get; set; }
    }
}
