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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-SRUKDV2;database=VipnetAsansorDb;integrated security=true;TrustServerCertificate=true");
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutTranslation> AboutTranslations { get; set; }

        public DbSet<Arge> Arges { get; set; }
        public DbSet<ArgeTranslation> ArgeTranslations { get; set; }

        public DbSet<MasterBrand> MasterBrands { get; set; }
        public DbSet<MasterBrandTranslation> MasterBrandTranslations { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandTranslation> BrandTranslations { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactTranslation> ContactTranslations { get; set; }

        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureTranslation> FeatureTranslations { get; set; }

        public DbSet<Header> Headers { get; set; }
        public DbSet<HeaderTranslation> HeaderTranslations { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionTranslation> QuestionTranslations { get; set; }

        public DbSet<Reference> References { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<SkillTranslation> SkillTranslations { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Topbar> Topbars { get; set; }


    }
}
