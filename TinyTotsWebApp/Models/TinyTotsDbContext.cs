using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TinyTotsWebApp.Models
{
    public class TinyTotsDbContext : DbContext
    {
        public DbSet<TinyTots> TinyTotsTable { get; set; }
    }
    // <TinyTots> refers to TinyTotsmodel 
    // TinyTotsTable refers to the table name that will store the data in the database
}