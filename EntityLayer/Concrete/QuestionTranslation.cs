using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionTranslation
    {
        [Key]
        public int QuestionTranslationID { get; set; }
        public int QuestionID { get; set; }
        public string? Language { get; set; }
        public string? TranslatedTitle { get; set; }
        public string? TranslatedName { get; set; }
        public string? TranslatedDescription { get; set; }

        // Navigasyon özelliği
        public Questions? Question { get; set; }
    }

}
