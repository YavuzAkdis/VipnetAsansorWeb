﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message // İletişim Mesaj Kutusu
    {
        [Key]
        public int MessageID { get; set; }

     
        public string? Name { get; set; }

        public string? Mail { get; set; }
        
        public string? Content { get; set; }

        public string? _Message { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

    }
}
