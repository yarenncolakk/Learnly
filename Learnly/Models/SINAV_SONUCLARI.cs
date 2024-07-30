using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("SINAV_SONUCLARI")]
    public class SINAV_SONUCLARI
    {
        [Key]
        public int sinav_sonuc_id { get; set; } 
        public int sinav_id { get; set; }   
        public int kullanici_id { get; set; }   
        public int toplam_dogru_sayisi {  get; set; }   
        public int toplam_yanlis_sayisi { get; set; }
        public DateTime sinav_tarihi { get; set; }  

    }
}