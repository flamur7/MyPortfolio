using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class DatabaseTechnology
    {
        [Key]
        public int DatabaseTechnologyId { get; set; }

        [Display(Name = "Database        ")]
        public string DatabaseTechnologyName { get; set; }

        public virtual ICollection<ProjectMade> ProjectMades { get; set; }
        public virtual ICollection<Collaborators> Collaboratorss { get; set; }
    }
}
