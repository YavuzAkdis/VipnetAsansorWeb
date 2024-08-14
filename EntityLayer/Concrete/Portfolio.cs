using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }

        public string? Language { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? P1 { get; set; }
        public string? P2 { get; set; }
        public string? P3 { get; set; }

        public string? S1 { get; set; }
        public string? SP1 { get; set; }

        public string? S2 { get; set; }
        public string? SP2 { get; set; }
       
    }

}
