using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.Models
{
    public class DatabaseTechnology
    {
        [Key]
        public int DatabaseTechnologyId { get; set; }
        public string DatabaseTechnologyName { get; set; }

        public virtual ICollection<ProjectMade> ProjectMades { get; set; }
        public virtual ICollection<Collaborators> Collaboratorss { get; set; }
    }
}
