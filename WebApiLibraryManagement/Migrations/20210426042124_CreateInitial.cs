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
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
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
                    { 1, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(1734), "Manh", "Male", "Nguyen", null },
                    { 2, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(2674), "Linh", "Female", "Tran", null },
                    { 3, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(2679), "Huong", "Female", "Nguyen", null },
                    { 4, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(2681), "Mai", "Female", "Bui", null },
                    { 5, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(2683), "Kien", "Male", "Do", null },
                    { 6, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(2684), "Dung", "Male", "Nguyen", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(2947), null, "Front End" },
                    { 2, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(4035), null, "Back End" },
                    { 3, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(4042), null, "Arts & Music" },
                    { 4, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(4044), null, "Biographies" },
                    { 5, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(4046), null, "Business" },
                    { 6, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(4048), null, "Comics" },
                    { 7, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(4050), null, "Computers & Tech" }
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
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedDate", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2021, 4, 26, 11, 21, 23, 453, DateTimeKind.Local).AddTicks(5951), null, "JavaScript" },
                    { 12, 1, 7, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8053), null, "Adobe Photoshop CS3 for Photographers : A Professional Image Editor's Guide to the Creative Use of Photoshop for the Macintosh and PC" },
                    { 11, 1, 6, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8051), null, "Naruto, Vol. 3" },
                    { 10, 1, 5, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8050), null, "Do What You Are : Discover the Perfect Career for You Through the Secrets of Personality Type" },
                    { 8, 1, 3, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8047), null, "Persepolis : The Story of a Childhood" },
                    { 7, 1, 2, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8045), null, "Note Js" },
                    { 9, 1, 4, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8048), null, "Narrative of the Life of Frederick Douglass, an American Slave" },
                    { 2, 2, 2, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8009), null, "C#" },
                    { 5, 5, 1, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8042), null, "React" },
                    { 4, 4, 1, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8041), null, "CSS" },
                    { 3, 3, 1, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8038), null, "HTML" },
                    { 6, 6, 2, new DateTime(2021, 4, 26, 11, 21, 23, 454, DateTimeKind.Local).AddTicks(8043), null, "Unit Test" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "Avatar", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "ModifiedDate", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 5, "Nghe An", 20, null, new DateTime(2021, 4, 26, 11, 21, 23, 457, DateTimeKind.Local).AddTicks(668), new DateTime(2001, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "hung@gmail.com", "Hung", "Male", "Nguyen", null, "123456", "0789456123", 2 },
                    { 1, "Ha Noi", 24, null, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(9327), new DateTime(1997, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "manh@gmail.com", "Manh", "Male", "Nguyen", null, "123456", "0123456789", 1 },
                    { 2, "Quang Ninh", 23, null, new DateTime(2021, 4, 26, 11, 21, 23, 457, DateTimeKind.Local).AddTicks(656), new DateTime(1998, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "tung@gmail.com", "Tung", "Male", "Tran", null, "123456", "0987654321", 2 },
                    { 3, "Ha Noi", 22, null, new DateTime(2021, 4, 26, 11, 21, 23, 457, DateTimeKind.Local).AddTicks(660), new DateTime(1999, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "trang@gmail.com", "Trang", "Female", "Bui", null, "123456", "0123789456", 2 },
                    { 4, "Ho Chi Minh", 21, null, new DateTime(2021, 4, 26, 11, 21, 23, 457, DateTimeKind.Local).AddTicks(665), new DateTime(2000, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "thu@gmail.com", "Thu", "Female", "Nguyen", null, "123456", "0456123789", 2 },
                    { 6, "Da Nang", 19, null, new DateTime(2021, 4, 26, 11, 21, 23, 457, DateTimeKind.Local).AddTicks(672), new DateTime(2002, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "toan@gmail.com", "Toan", "Male", "Tran", null, "123456", "0789123456", 2 }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRequestDetails",
                columns: new[] { "Id", "BookId", "BorrowRequestId", "BorrowingRequestId" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 3, 3, null, 1 },
                    { 4, 4, null, 1 },
                    { 5, 5, null, 2 },
                    { 2, 2, null, 1 },
                    { 6, 6, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRequests",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(4713), null, "Approved", 1 },
                    { 2, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(6344), null, "Approved", 1 },
                    { 3, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(6363), null, "Waiting", 2 },
                    { 4, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(6366), null, "Rejected", 3 },
                    { 5, new DateTime(2021, 4, 26, 11, 21, 23, 456, DateTimeKind.Local).AddTicks(6370), null, "Approved", 4 }
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
