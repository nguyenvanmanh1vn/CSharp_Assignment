using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibraryManagement.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowingRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowingRequestId = table.Column<int>(type: "int", nullable: false),
                    BorrowRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowingRequestDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingRequestDetails_BorrowingRequests_BorrowRequestId",
                        column: x => x.BorrowRequestId,
                        principalTable: "BorrowingRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedDate", "FirstName", "Gender", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 26, 20, 29, 0, 689, DateTimeKind.Local).AddTicks(9181), "Marjane", "Female", "Satrapi", null },
                    { 2, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(210), "Frederick", "Male", "Douglass", null },
                    { 3, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(217), "Barbara", "Female", "Barron", null },
                    { 4, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(218), "Masashi", "Male", "Kishimoto", null },
                    { 5, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(220), "Martin", "Male", "Evening", null },
                    { 6, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(222), "Amadea", "Female", "Morningstar", null },
                    { 7, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(224), "Elizabeth", "Female", "Zimmermann", null },
                    { 8, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(226), "Al", "Male", "Seckel", null },
                    { 9, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(228), "Ann", "Female", "Lawson Christine", null },
                    { 10, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(229), "Deibler ", "Female", "Rose Darlene", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1353), null, "History Books " },
                    { 9, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1352), null, "Health & Fitness" },
                    { 8, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1350), null, "Logic & Brain Teaser Books" },
                    { 7, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1348), null, "Education & Reference" },
                    { 6, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1346), null, "Cooking" },
                    { 1, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(622), null, "Arts & Music" },
                    { 4, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1343), null, "Comics" },
                    { 3, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1342), null, "Business" },
                    { 2, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1337), null, "Biographies" },
                    { 5, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1345), null, "Computers & Tech" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleDescription", "UserRoles" },
                values: new object[,]
                {
                    { 1, "Admin can do the following actions: Viewing/Adding/Updating/Deleting a Category; Viewing/Adding/Updating/Deleting a Book; Viewing the list of borrowing requests; Approving/Rejecting request from Normal User", "Admin" },
                    { 2, "User can do the following actions: Borrowing book. One borrowing request can request more than 1 book (maximum is 5 books and 3 borrowing requests in a month); Normal User can see the list of books that he/she already borrowed with status (Approve/Reject/Waiting)", "User" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedDate", "Image", "ModifiedDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2021, 4, 26, 20, 29, 0, 687, DateTimeKind.Local).AddTicks(2607), "https://img.thriftbooks.com/api/images/m/2540127da455500c49d0c50c71683b6f38f0b70b.jpg", null, "Exist", "Persepolis : The Story of a Childhood" },
                    { 2, 2, 2, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5289), "https://img.thriftbooks.com/api/images/m/8303521a462dc3511f365b692830e3e16b370742.jpg", null, "Borowed", "Narrative of the Life of Frederick Douglass, an American Slave" },
                    { 3, 3, 3, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5315), "https://img.thriftbooks.com/api/images/m/721d5caa481de1e0b2ac04205606f92cce1adeae.jpg", null, "Exist", "Do What You Are : Discover the Perfect Career for You Through the Secrets of Personality Type" },
                    { 4, 4, 4, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5318), "https://img.thriftbooks.com/api/images/m/456fbecc05164ed1e327ff5ee9922475d1e38df0.jpg", null, "Exist", "Naruto, Vol. 3" },
                    { 5, 5, 5, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5319), "https://img.thriftbooks.com/api/images/m/f1690297c45711d15406be34e5397b6fcf843718.jpg", null, "Exist", "Adobe Photoshop CS3 for Photographers : A Professional Image Editor's Guide to the Creative Use of Photoshop for the Macintosh and PC" },
                    { 6, 6, 6, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5321), "https://img.thriftbooks.com/api/images/m/5ac192845cdf424b29b55fbfa03e0db7e0d278ff.jpg", null, "Exist", "The Ayurvedic Cookbook" },
                    { 7, 7, 7, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5322), "https://img.thriftbooks.com/api/images/m/d7b2a08125cda604e3ba179b5f2fa64f56ee8583.jpg", null, "Exist", "Elizabeth Zimmermann's Knitter's Almanac" },
                    { 8, 8, 8, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5324), "https://m.media-amazon.com/images/I/51788Fh430L._SL350_.jpg", null, "Exist", "The Ultimate Book of Optical Illusions" },
                    { 9, 9, 9, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5326), "https://img.thriftbooks.com/api/images/m/8007fc770cbec3c2baaa3026595550d44fc907d4.jpg", null, "Exist", "Understanding the Borderline Mother : Helping Her Children Transcend the Intense, Unpredictable, and Volatile Relationship" },
                    { 10, 10, 10, new DateTime(2021, 4, 26, 20, 29, 0, 688, DateTimeKind.Local).AddTicks(5328), "https://m.media-amazon.com/images/I/415K3VeI3zL._SL350_.jpg", null, "Exist", "Evidence Not Seen: A Woman's Miraculous Faith in the Jungles of World War II" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "Avatar", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "ModifiedDate", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "Ha Noi", 24, null, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(4092), new DateTime(1997, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "manh@gmail.com", "Manh", "Male", "Nguyen", null, "123456", "0123456789", 1 },
                    { 2, "Quang Ninh", 23, null, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(5207), new DateTime(1998, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "tung@gmail.com", "Tung", "Male", "Tran", null, "123456", "0987654321", 2 },
                    { 3, "Ha Noi", 22, null, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(5211), new DateTime(1999, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "trang@gmail.com", "Trang", "Female", "Bui", null, "123456", "0123789456", 2 },
                    { 4, "Ho Chi Minh", 21, null, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(5215), new DateTime(2000, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "thu@gmail.com", "Thu", "Female", "Nguyen", null, "123456", "0456123789", 2 },
                    { 5, "Nghe An", 20, null, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(5218), new DateTime(2001, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "hung@gmail.com", "Hung", "Male", "Nguyen", null, "123456", "0789456123", 2 },
                    { 6, "Da Nang", 19, null, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(5221), new DateTime(2002, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "toan@gmail.com", "Toan", "Male", "Tran", null, "123456", "0789123456", 2 }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRequestDetails",
                columns: new[] { "Id", "BookId", "BorrowRequestId", "BorrowingRequestId" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 2, 2, null, 1 },
                    { 3, 3, null, 1 },
                    { 4, 4, null, 1 },
                    { 5, 5, null, 2 },
                    { 6, 6, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRequests",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(1561), null, "Approved", 1 },
                    { 2, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(2477), null, "Approved", 1 },
                    { 3, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(2483), null, "Waiting", 2 },
                    { 4, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(2485), null, "Rejected", 3 },
                    { 5, new DateTime(2021, 4, 26, 20, 29, 0, 690, DateTimeKind.Local).AddTicks(2487), null, "Approved", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequestDetails_BookId",
                table: "BorrowingRequestDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequestDetails_BorrowRequestId",
                table: "BorrowingRequestDetails",
                column: "BorrowRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequests_UserId",
                table: "BorrowingRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowingRequestDetails");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BorrowingRequests");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
