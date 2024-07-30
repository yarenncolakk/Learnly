using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("SINAV_ADLARI")]
    public class SINAV_ADLARI
    {
        [Key]
        public int sinav_adi_id { get; set; }   
        public string sinav_id {  get; set; }

    }
}