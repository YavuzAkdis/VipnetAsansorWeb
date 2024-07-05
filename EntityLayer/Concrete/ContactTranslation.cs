using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactTranslation
    {
        [Key]
        public int ContactTranslationID { get; set; }
        public int ContactID { get; set; }
        public string? Language { get; set; }
        public string? TranslatedPhone { get; set; }
        public string? TranslatedMail { get; set; }
        public string? TranslatedAddress { get; set; }
        public string? TranslatedMaps { get; set; }

        // Navigasyon özelliği
        public Contact? Contact { get; set; }
    }

}
