
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Models
{
    public class PersonalUser
    {
        [Key]
        public int PersonalUserId { get; set; }
        public string PersonalFullName { get; set; }
        public string Birthplace { get; set; }
        public string Email { get; set; }
        public string GitLink { get; set; }

        //[Display(Name = "Skills")]
        //public int SkillId { get; set; }
        //[ForeignKey("SkillId")]
        ////public virtual Skill Skill { get; set; }
    }
}
