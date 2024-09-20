using ITI_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
namespace ITI_Final_Project.Context
{
    public class MarketContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TAISON;DataBase=ITI_Final_Project;Trusted_Connection=true;Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var _Categorys = new List<Category>
            { 
                new Category{CategoryId=1,Name="Dairy Department",Description="Dairy" },
                new Category{CategoryId=2,Name="Meat Department",Description="meats"},
                new Category{CategoryId=3,Name="Vegetables and Fruits Department",Description="Vegetables and Fruits"},
                new Category{CategoryId=4,Name="Fast Food Department",Description="snackes"}
            };
            var _Products = new List<Product>
            {
                new Product{ProductId=1,Title="Fish",Price="15$",Description="Eating fish is a great alternative to eating red meat, potentially providing a broad range of health benefits — from heart health to improved symptoms of depression.",Quantitiy=50,ImagePath="/images/R.png",CategoryId=2},
                new Product{ProductId=2,Title="Milk",Price="8$",Description="Keep muscles, bones, nerves, teeth, skin and vision healthy\r\nRelease energy from foods and reduce tiredness and fatigue\r\nMaintain healthy blood pressure\r\nSupport normal growth and brain development\r\nAnd even support normal immune functioning",Quantitiy=70,ImagePath="/images/Milk.png",CategoryId=1},
                new Product{ProductId=3,Title="Meat",Price="25$",Description="Nutritional Value: Meat, particularly red meat, is rich in high-quality protein, essential amino acids, iron, zinc, and vitamin B12, which are crucial for muscle development, immune function, and overall energy levels.\r\nModeration and Balance: While meat can be an excellent source of nutrients, excessive consumption, especially of processed or red meats, has been linked to health risks such as heart disease, certain cancers, and high cholesterol. It’s important to maintain a balanced diet that includes a variety of food groups.\r\nAlternative Proteins: For those looking to reduce or eliminate meat from their diet, plant-based proteins such as legumes, tofu, and tempeh, as well as lean animal-based proteins like fish and poultry, can provide similar benefits with fewer health risks.",Quantitiy=19,ImagePath="/images/beef-meat.png",CategoryId=2},
                new Product{ProductId=4,Title="Apple",Price="5$",Description="Rich in Nutrients: Apples are a great source of important vitamins, including vitamin C, which supports the immune system, and fiber, which promotes digestive health. A medium-sized apple contains around 4 grams of dietary fiber, which helps maintain healthy cholesterol levels and regulate blood sugar.\r\nAntioxidant Powerhouse: Apples contain powerful antioxidants like quercetin and flavonoids, which may help reduce inflammation and protect against chronic diseases such as heart disease and certain cancers.\r\nWeight Management: Low in calories and high in water content, apples are a filling snack that can aid in weight management. Their natural sweetness makes them a healthier alternative to processed sugary treats.\r\nHeart Health: Regular consumption of apples has been linked to better heart health due to their fiber, potassium, and antioxidant content, all of which can help lower blood pressure and reduce the risk of stroke.",Quantitiy=1010,ImagePath="/images/apple_PNG12425.png",CategoryId=3}
            };
            modelBuilder.Entity<Product>().HasData(_Products);
            modelBuilder.Entity<Category>().HasData(_Categorys);
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
