using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class OtherTechnology
    {
        [Key]
        public int OtherTechnologyId { get; set; }
        public string OtherTechnologyName { get; set; }


        public virtual ICollection<ProjectMade> ProjectMades { get; set; }
        public virtual ICollection<Collaborators> Collaboratorss { get; set; }
    }
}
