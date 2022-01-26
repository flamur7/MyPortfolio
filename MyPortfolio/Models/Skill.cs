using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }


        public virtual ICollection<PersonalUser> PersonalUsers { get; set; }
    }
}
