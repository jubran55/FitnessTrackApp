using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackApp.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTFoodType",
                columns: table => new
                {
                    FoodTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeNameEnglish = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TypeNameArabic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MtFoodTy__516F03B50CA9EA02", x => x.FoodTypeID);
                });

            migrationBuilder.CreateTable(
                name: "MTFoodNutrition",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodNameEnglish = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    FoodNameArabic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FoodTypeID = table.Column<int>(type: "int", nullable: true),
                    weight100 = table.Column<int>(type: "int", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: true),
                    Protein = table.Column<double>(type: "float", nullable: true),
                    Carbohydrates = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    DietaryFiber = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MtFoodNu__3214EC27EE34EC3B", x => x.FoodID);
                    table.ForeignKey(
                        name: "FK_MtFoodNutrition_MtFoodType",
                        column: x => x.FoodTypeID,
                        principalTable: "MTFoodType",
                        principalColumn: "FoodTypeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MTFoodNutrition_FoodTypeID",
                table: "MTFoodNutrition",
                column: "FoodTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MTFoodNutrition");

            migrationBuilder.DropTable(
                name: "MTFoodType");
        }
    }
}
