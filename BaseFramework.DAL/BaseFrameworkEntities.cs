using BaseFramework.Entity.ProjectBaseEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.DAL
{//toolstan nugetpacckademanagerdan consolu seçiyoruz //enable-migrations yazarız //migrations kısmı geliyor
    //add-migration initialize yazıyoruz // update-database
   public  class BaseFrameworkEntities :DbContext
    {
        public BaseFrameworkEntities() : base("name=BaseFrameworkDB")
        {

        }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageEvent> PageEvents { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
