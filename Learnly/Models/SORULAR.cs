using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("SORULAR")]
    public class SORULAR
    {
        [Key] 
        public int soru_id { get; set; }    
        public string soru {  get; set; }   
        public string A {  get; set; }  
        public string B { get; set; }   
        public string C { get; set; }   
        public string D { get; set; }   
        public string E { get; set; }   
        public int brans_id {  get; set; }  
        public int konu_id { get; set; }    
        public string soru_cevabi {  get; set; }

    }
}