using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class ProjectMade
    {
        [Key]
        public int ProjectMadeId { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectMadeName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ProjectMadeDescription { get; set; }

        [Required]
        [Display(Name = "Project Image")]
        public string Image { get; set; }

        [Required]
        public int BackEndTechnologyId { get; set; }
        [ForeignKey("BackEndTechnologyId")]
        [Display(Name = "Back-End")]
        public virtual BackEndTechnology BackEndTechnology { get; set; }

        [Required]
        public int FrontEndTechnologyId { get; set; }
        [ForeignKey("FrontEndTechnologyId")]
        [Display(Name = "Front-End")]
        public virtual FrontEndTechnology FrontEndTechnology { get; set; }

        [Required]
        public int OtherTechnologyId { get; set; }
        [ForeignKey("OtherTechnologyId")]
        [Display(Name = "Others")]
        public virtual OtherTechnology OtherTechnology { get; set; }

        [Required]
        [Display(Name = "Database")]
        public int DatabaseTechnologyId { get; set; }
        [ForeignKey("DatabaseTechnologyId")]
        [Display(Name = "Database")]
        public virtual DatabaseTechnology DatabaseTechnology { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }

    }
}
