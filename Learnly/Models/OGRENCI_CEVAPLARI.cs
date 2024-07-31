using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("OGRENCI_CEVAPLARI")]
    public class OGRENCI_CEVAPLARI
    {
        [Key]
        public int ogrenci_cevabi_id {  get; set; } 
        public int kullanici_id { get; set; }   
        public int soru_id { get; set; } 
        public int sinav_id { get; set; }   
        public string cevap {  get; set; }  
    }
}