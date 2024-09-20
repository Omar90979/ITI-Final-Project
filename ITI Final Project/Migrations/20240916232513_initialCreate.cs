using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantitiy = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Dairy", "Dairy Department" },
                    { 2, "meats", "Meat Department" },
                    { 3, "Vegetables and Fruits", "Vegetables and Fruits Department" },
                    { 4, "snackes", "Fast Food Department" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "Price", "Quantitiy", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Eating fish is a great alternative to eating red meat, potentially providing a broad range of health benefits — from heart health to improved symptoms of depression.", "/images/R.png", "15$", 50, "Fish" },
                    { 2, 1, "Keep muscles, bones, nerves, teeth, skin and vision healthy\r\nRelease energy from foods and reduce tiredness and fatigue\r\nMaintain healthy blood pressure\r\nSupport normal growth and brain development\r\nAnd even support normal immune functioning", "/images/Milk.png", "8$", 70, "Milk" },
                    { 3, 2, "Nutritional Value: Meat, particularly red meat, is rich in high-quality protein, essential amino acids, iron, zinc, and vitamin B12, which are crucial for muscle development, immune function, and overall energy levels.\r\nModeration and Balance: While meat can be an excellent source of nutrients, excessive consumption, especially of processed or red meats, has been linked to health risks such as heart disease, certain cancers, and high cholesterol. It’s important to maintain a balanced diet that includes a variety of food groups.\r\nAlternative Proteins: For those looking to reduce or eliminate meat from their diet, plant-based proteins such as legumes, tofu, and tempeh, as well as lean animal-based proteins like fish and poultry, can provide similar benefits with fewer health risks.", "/images/beef-meat.png", "25$", 19, "Meat" },
                    { 4, 3, "Rich in Nutrients: Apples are a great source of important vitamins, including vitamin C, which supports the immune system, and fiber, which promotes digestive health. A medium-sized apple contains around 4 grams of dietary fiber, which helps maintain healthy cholesterol levels and regulate blood sugar.\r\nAntioxidant Powerhouse: Apples contain powerful antioxidants like quercetin and flavonoids, which may help reduce inflammation and protect against chronic diseases such as heart disease and certain cancers.\r\nWeight Management: Low in calories and high in water content, apples are a filling snack that can aid in weight management. Their natural sweetness makes them a healthier alternative to processed sugary treats.\r\nHeart Health: Regular consumption of apples has been linked to better heart health due to their fiber, potassium, and antioxidant content, all of which can help lower blood pressure and reduce the risk of stroke.", "/images/apple_PNG12425.png", "5$", 1010, "Apple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
