﻿// <auto-generated />
using ITI_Final_Project.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITI_Final_Project.Migrations
{
    [DbContext(typeof(MarketContext))]
    [Migration("20240916232513_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITI_Final_Project.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Dairy",
                            Name = "Dairy Department"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "meats",
                            Name = "Meat Department"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Vegetables and Fruits",
                            Name = "Vegetables and Fruits Department"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "snackes",
                            Name = "Fast Food Department"
                        });
                });

            modelBuilder.Entity("ITI_Final_Project.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantitiy")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            Description = "Eating fish is a great alternative to eating red meat, potentially providing a broad range of health benefits — from heart health to improved symptoms of depression.",
                            ImagePath = "/images/R.png",
                            Price = "15$",
                            Quantitiy = 50,
                            Title = "Fish"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "Keep muscles, bones, nerves, teeth, skin and vision healthy\r\nRelease energy from foods and reduce tiredness and fatigue\r\nMaintain healthy blood pressure\r\nSupport normal growth and brain development\r\nAnd even support normal immune functioning",
                            ImagePath = "/images/Milk.png",
                            Price = "8$",
                            Quantitiy = 70,
                            Title = "Milk"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            Description = "Nutritional Value: Meat, particularly red meat, is rich in high-quality protein, essential amino acids, iron, zinc, and vitamin B12, which are crucial for muscle development, immune function, and overall energy levels.\r\nModeration and Balance: While meat can be an excellent source of nutrients, excessive consumption, especially of processed or red meats, has been linked to health risks such as heart disease, certain cancers, and high cholesterol. It’s important to maintain a balanced diet that includes a variety of food groups.\r\nAlternative Proteins: For those looking to reduce or eliminate meat from their diet, plant-based proteins such as legumes, tofu, and tempeh, as well as lean animal-based proteins like fish and poultry, can provide similar benefits with fewer health risks.",
                            ImagePath = "/images/beef-meat.png",
                            Price = "25$",
                            Quantitiy = 19,
                            Title = "Meat"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3,
                            Description = "Rich in Nutrients: Apples are a great source of important vitamins, including vitamin C, which supports the immune system, and fiber, which promotes digestive health. A medium-sized apple contains around 4 grams of dietary fiber, which helps maintain healthy cholesterol levels and regulate blood sugar.\r\nAntioxidant Powerhouse: Apples contain powerful antioxidants like quercetin and flavonoids, which may help reduce inflammation and protect against chronic diseases such as heart disease and certain cancers.\r\nWeight Management: Low in calories and high in water content, apples are a filling snack that can aid in weight management. Their natural sweetness makes them a healthier alternative to processed sugary treats.\r\nHeart Health: Regular consumption of apples has been linked to better heart health due to their fiber, potassium, and antioxidant content, all of which can help lower blood pressure and reduce the risk of stroke.",
                            ImagePath = "/images/apple_PNG12425.png",
                            Price = "5$",
                            Quantitiy = 1010,
                            Title = "Apple"
                        });
                });

            modelBuilder.Entity("ITI_Final_Project.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ITI_Final_Project.Models.Product", b =>
                {
                    b.HasOne("ITI_Final_Project.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ITI_Final_Project.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
