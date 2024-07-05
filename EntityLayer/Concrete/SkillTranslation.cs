using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SkillTranslation 
    {
        [Key]
        public int SkillTranslationID { get; set; }
        public int SkillID { get; set; }
        public string? Language { get; set; }
        public string? TranslatedTitle { get; set; }
        public string? TranslatedDescription { get; set; }

        // Navigasyon özelliği
        public Skill? Skill { get; set; }
    }
}
