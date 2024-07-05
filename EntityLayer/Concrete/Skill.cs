using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill // Arge Yetenekler
    {
        [Key]
        public int SkillID { get; set; }
        public string? Icon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        // İhtiyaca bağlı olarak, dil tabanlı çeviriler için ek bir koleksiyon eklenebilir.
        public ICollection<SkillTranslation>? Translations { get; set; }
    }
}
