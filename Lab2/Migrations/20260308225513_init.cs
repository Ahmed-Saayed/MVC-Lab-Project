using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dep_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    Min_Degree = table.Column<int>(type: "int", nullable: false),
                    hourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dep_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_ID);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_Dep_ID",
                        column: x => x.Dep_ID,
                        principalTable: "Departments",
                        principalColumn: "Department_ID");
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Trainee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trainee_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeYear = table.Column<double>(type: "float", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dep_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Trainee_Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Departments_Dep_ID",
                        column: x => x.Dep_ID,
                        principalTable: "Departments",
                        principalColumn: "Department_ID");
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Inst_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inst_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Dep_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Inst_Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_Dep_ID",
                        column: x => x.Dep_ID,
                        principalTable: "Departments",
                        principalColumn: "Department_ID");
                });

            migrationBuilder.CreateTable(
                name: "crsResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Trainee_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crsResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_crsResults_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK_crsResults_Trainees_Trainee_ID",
                        column: x => x.Trainee_ID,
                        principalTable: "Trainees",
                        principalColumn: "Trainee_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Dep_ID",
                table: "Courses",
                column: "Dep_ID");

            migrationBuilder.CreateIndex(
                name: "IX_crsResults_Course_ID",
                table: "crsResults",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_crsResults_Trainee_ID",
                table: "crsResults",
                column: "Trainee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Course_id",
                table: "Instructors",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dep_ID",
                table: "Instructors",
                column: "Dep_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_Dep_ID",
                table: "Trainees",
                column: "Dep_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crsResults");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
