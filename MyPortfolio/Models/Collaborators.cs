using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class Collaborators
    {
        [Key]
        public int CollaboratorId { get; set; }
        public string CollaboratorFullName { get; set; }

        [Display(Name = "BackEnd Technology")]
        public int BackEndTechnologyId { get; set; }
        [ForeignKey("BackEndTechnologyId")]
        public virtual BackEndTechnology BackEndTechnology { get; set; }

        [Display(Name = "FrontEnd Technology")]
        public int FrontEndTechnologyId { get; set; }
        [ForeignKey("FrontEndTechnologyId")]
        public virtual FrontEndTechnology FrontEndTechnology { get; set; }

        [Display(Name = "Other Technologys")]
        public int OtherTechnologyId { get; set; }
        [ForeignKey("OtherTechnologyId")]
        public virtual OtherTechnology OtherTechnology { get; set; }

        [Display(Name = "Database")]
        public int DatabaseTechnologyId { get; set; }
        [ForeignKey("DatabaseTechnologyId")]
        public virtual DatabaseTechnology DatabaseTechnology { get; set; }

        
    }
}
