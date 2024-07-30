using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    public class myDbContext:DbContext
    {
        public myDbContext() : base("name=myDbContext")
        {

        }
        public DbSet<KULLANICILAR> user {  get; set; }
        public DbSet<BRANSLAR> branch {  get; set; }    
        public DbSet<ROLLER> role { get; set; } 
        public DbSet<SORULAR> question { get; set; }    
        public DbSet<OGRENCI_CEVAPLARI> std_answ {  get; set; } 
        public DbSet<DOGRU_CEVAPLAR> correct_answ { get; set; } 
        public DbSet<KONULAR> topic { get; set; }
        public DbSet<SINAV_SORULARI> exm_question { get; set; } 
        public DbSet<SINAV_SONUCLARI> exm_result { get; set; }  
        public DbSet<SINAV_ADLARI> exm_name { get; set; }

      

    }
}