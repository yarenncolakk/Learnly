using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("SINAV_SORULARI")]
    public class SINAV_SORULARI
    {
        [Key]
        public int sinav_soru_id { get; set; }  
        public int sinav_id { get; set; }   
        public int soru_id { get; set; }
    }
}