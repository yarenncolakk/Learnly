using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("DOGRU_CEVAPLAR")]
    public class DOGRU_CEVAPLAR
    {
        [Key]
        public int dogru_cevap_id { get; set; } 
        public int soru_id { get; set; }    
        public string cevap {  get; set; }  
    }
}