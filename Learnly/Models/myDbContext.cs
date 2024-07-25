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

      

    }
}