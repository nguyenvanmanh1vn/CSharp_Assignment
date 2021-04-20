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
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    BorrowingRequestId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_BorrowingRequestDetails_BorrowingRequests_BorrowingRequestId",
                        column: x => x.BorrowingRequestId,
                        principalTable: "BorrowingRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedDate", "FirstName", "Gender", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(236), "Manh", "Male", "Nguyen", null },
                    { 2, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(3097), "Linh", "Female", "Tran", null },
                    { 3, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(3116), "Huong", "Female", "Nguyen", null },
                    { 4, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(3120), "Mai", "Female", "Bui", null },
                    { 5, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(3125), "Kien", "Male", "Do", null },
                    { 6, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(3130), "Dung", "Male", "Nguyen", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(3682), null, "Front End" },
                    { 2, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(5156), null, "Back End" }
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
                    { 1, 1, 1, new DateTime(2021, 4, 20, 15, 13, 40, 478, DateTimeKind.Local).AddTicks(6879), null, "JavaScript" },
                    { 3, 3, 1, new DateTime(2021, 4, 20, 15, 13, 40, 480, DateTimeKind.Local).AddTicks(336), null, "HTML" },
                    { 4, 4, 1, new DateTime(2021, 4, 20, 15, 13, 40, 480, DateTimeKind.Local).AddTicks(340), null, "CSS" },
                    { 5, 5, 1, new DateTime(2021, 4, 20, 15, 13, 40, 480, DateTimeKind.Local).AddTicks(344), null, "React" },
                    { 2, 2, 2, new DateTime(2021, 4, 20, 15, 13, 40, 480, DateTimeKind.Local).AddTicks(297), null, "C#" },
                    { 6, 6, 2, new DateTime(2021, 4, 20, 15, 13, 40, 480, DateTimeKind.Local).AddTicks(346), null, "Unit Test" },
                    { 7, 1, 2, new DateTime(2021, 4, 20, 15, 13, 40, 480, DateTimeKind.Local).AddTicks(429), null, "Note Js" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Age", "Avatar", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "ModifiedDate", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "Ha Noi", 24, null, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(9785), new DateTime(1997, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "manh@gmail.com", "Manh", "Male", "Nguyen", null, "123456", "0123456789", 1 },
                    { 2, "Quang Ninh", 23, null, new DateTime(2021, 4, 20, 15, 13, 40, 484, DateTimeKind.Local).AddTicks(2644), new DateTime(1998, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "tung@gmail.com", "Tung", "Male", "Tran", null, "123456", "0987654321", 2 },
                    { 3, "Ha Noi", 22, null, new DateTime(2021, 4, 20, 15, 13, 40, 484, DateTimeKind.Local).AddTicks(2655), new DateTime(1999, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "trang@gmail.com", "Trang", "Female", "Bui", null, "123456", "0123789456", 2 },
                    { 4, "Ho Chi Minh", 21, null, new DateTime(2021, 4, 20, 15, 13, 40, 484, DateTimeKind.Local).AddTicks(2664), new DateTime(2000, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "thu@gmail.com", "Thu", "Female", "Nguyen", null, "123456", "0456123789", 2 },
                    { 5, "Nghe An", 20, null, new DateTime(2021, 4, 20, 15, 13, 40, 484, DateTimeKind.Local).AddTicks(2673), new DateTime(2001, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "hung@gmail.com", "Hung", "Male", "Nguyen", null, "123456", "0789456123", 2 },
                    { 6, "Da Nang", 19, null, new DateTime(2021, 4, 20, 15, 13, 40, 484, DateTimeKind.Local).AddTicks(2682), new DateTime(2002, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "toan@gmail.com", "Toan", "Male", "Tran", null, "123456", "0789123456", 2 }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRequests",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(5541), null, "Approved", 1 },
                    { 2, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(6673), null, "Approved", 1 },
                    { 3, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(6687), null, "Waiting", 2 },
                    { 4, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(6690), null, "Rejected", 3 },
                    { 5, new DateTime(2021, 4, 20, 15, 13, 40, 483, DateTimeKind.Local).AddTicks(6692), null, "Approved", 4 }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRequestDetails",
                columns: new[] { "Id", "BookId", "BorrowingRequestId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 2 },
                    { 6, 6, 3 }
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
                name: "IX_BorrowingRequestDetails_BorrowingRequestId",
                table: "BorrowingRequestDetails",
                column: "BorrowingRequestId");

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
