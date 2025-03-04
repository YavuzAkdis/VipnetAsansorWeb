﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Partner // Arge Patnerler
    {
        [Key]
        public int PartnerID { get; set; }
        public string? Name { get; set;}
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image_File { get; set; }
    }
}
