using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext // Veri Bağlantısını Tutan Sınıf
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=desktop-srukdv2;database=VipnetAsansorDb;integrated security=true;Trustservercertificate=true");
            optionsBuilder.UseSqlServer("server=77.245.159.23\\MSSQLSERVER2019;database=VipnetAsansorDb;user=user01;password=Yavuz-123;TrustServerCertificate=True;");

        }


        public DbSet<About> Abouts { get; set; }
      
        public DbSet<Arge> Arges { get; set; }
     
        public DbSet<Gallery> Galleries { get; set; }
      
        public DbSet<MasterBrand> MasterBrands { get; set; }
     
        public DbSet<Brand> Brands { get; set; }
       
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<Contact> Contacts { get; set; }
       
        public DbSet<Feature> Features { get; set; }
      
        public DbSet<Header> Headers { get; set; }
    
        public DbSet<Message> Messages { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Product> Products { get; set; }
  
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Questions> Questions { get; set; }
  

        public DbSet<Reference> References { get; set; }
        public DbSet<Skill> Skills { get; set; }

       
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Topbar> Topbars { get; set; }

        public DbSet<User> Users { get; set; }


    }
}
