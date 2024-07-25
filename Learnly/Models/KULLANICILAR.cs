using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("KULLANICILAR")]
    public class KULLANICILAR
    {
        [Key]
        public int kullanici_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string eposta { get; set;}
        public string parola { get; set; }
        public int rol_id { get; set; }
        public int? brans_id { get; set; } //? null olabilir anlamında.
    }
}