using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class Collaborators
    {
        [Key]
        public int CollaboratorId { get; set; }

        [Display(Name = "Collaborator")]
        public string CollaboratorFullName { get; set; }

        [Display(Name = "Description")]
        public string CollaboratorDescription { get; set; }



        public int BackEndTechnologyId { get; set; }
        [ForeignKey("BackEndTechnologyId")]
        [Display(Name = "Back-End")]
        public virtual BackEndTechnology BackEndTechnology { get; set; }

        public int FrontEndTechnologyId { get; set; }
        [ForeignKey("FrontEndTechnologyId")]
        [Display(Name = "Front-End")]
        public virtual FrontEndTechnology FrontEndTechnology { get; set; }


        public int DatabaseTechnologyId { get; set; }
        [ForeignKey("DatabaseTechnologyId")]
        [Display(Name = "Database")]
        public virtual DatabaseTechnology DatabaseTechnology { get; set; }

        public int OtherTechnologyId { get; set; }
        [ForeignKey("OtherTechnologyId")]
        [Display(Name = "Others")]
        public virtual OtherTechnology OtherTechnology { get; set; }


        
    }
}
