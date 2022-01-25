using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.Models
{
    public class FrontEndTechnology
    {
        [Key]
        public int FrontEndTechnologyId { get; set; }
        public string FrontEndName { get; set; }

        public virtual ICollection<ProjectMade> ProjectMades { get; set; }
        public virtual ICollection<Collaborators> Collaboratorss { get; set; }
    }
}
