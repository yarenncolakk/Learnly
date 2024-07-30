using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("KONULAR")]
    public class KONULAR
    {
        [Key]
        public int konu_id { get; set; }    
        public string konu_ad {  get; set; }    
        public int brans_id { get; set; }   
    }
}