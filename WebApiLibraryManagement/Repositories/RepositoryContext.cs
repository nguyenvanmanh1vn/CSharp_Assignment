using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApiLibraryManagement.Models;

namespace WebApiLibraryManagement.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) :
            base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowRequest> BorrowingRequests { get; set; }
        public DbSet<BorrowRequestDetail> BorrowingRequestDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data Seeding
            // Book List
            modelBuilder.Entity<Book>().HasData(
                new { Id = 1, Title = "JavaScript", AuthorId = 1, CategoryId = 1, CreatedDate = DateTime.Now },
                new { Id = 2, Title = "C#", AuthorId = 2, CategoryId = 2, CreatedDate = DateTime.Now },
                new { Id = 3, Title = "HTML", AuthorId = 3, CategoryId = 1, CreatedDate = DateTime.Now },
                new { Id = 4, Title = "CSS", AuthorId = 4, CategoryId = 1, CreatedDate = DateTime.Now },
                new { Id = 5, Title = "React", AuthorId = 5, CategoryId = 1, CreatedDate = DateTime.Now },
                new { Id = 6, Title = "Unit Test", AuthorId = 6, CategoryId = 2, CreatedDate = DateTime.Now },
                new { Id = 7, Title = "Note Js", AuthorId = 1, CategoryId = 2, CreatedDate = DateTime.Now },
                new { Id = 8, Title = "Persepolis : The Story of a Childhood", AuthorId = 1, CategoryId = 3, CreatedDate = DateTime.Now },
                new { Id = 9, Title = "Narrative of the Life of Frederick Douglass, an American Slave", AuthorId = 1, CategoryId = 4, CreatedDate = DateTime.Now },
                new { Id = 10, Title = "Do What You Are : Discover the Perfect Career for You Through the Secrets of Personality Type", AuthorId = 1, CategoryId = 5, CreatedDate = DateTime.Now },
                new { Id = 11, Title = "Naruto, Vol. 3", AuthorId = 1, CategoryId = 6, CreatedDate = DateTime.Now },
                new { Id = 12, Title = "Adobe Photoshop CS3 for Photographers : A Professional Image Editor's Guide to the Creative Use of Photoshop for the Macintosh and PC", AuthorId = 1, CategoryId = 7, CreatedDate = DateTime.Now }
            );

            // Author List
            modelBuilder.Entity<Author>().HasData(
                new { Id = 1, FirstName = "Manh", LastName = "Nguyen", Gender = "Male", BookId = 1, CreatedDate = DateTime.Now },
                new { Id = 2, FirstName = "Linh", LastName = "Tran", Gender = "Female", BookId = 2, CreatedDate = DateTime.Now },
                new { Id = 3, FirstName = "Huong", LastName = "Nguyen", Gender = "Female", BookId = 3, CreatedDate = DateTime.Now },
                new { Id = 4, FirstName = "Mai", LastName = "Bui", Gender = "Female", BookId = 4, CreatedDate = DateTime.Now },
                new { Id = 5, FirstName = "Kien", LastName = "Do", Gender = "Male", BookId = 5, CreatedDate = DateTime.Now },
                new { Id = 6, FirstName = "Dung", LastName = "Nguyen", Gender = "Male", BookId = 6, CreatedDate = DateTime.Now }
            );

            // Category List
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Front End", BookId = 1, CreatedDate = DateTime.Now },
                new { Id = 2, Name = "Back End", BookId = 2, CreatedDate = DateTime.Now },
                new { Id = 3, Name = "Arts & Music", BookId = 8, CreatedDate = DateTime.Now },
                new { Id = 4, Name = "Biographies", BookId = 9, CreatedDate = DateTime.Now },
                new { Id = 5, Name = "Business", BookId = 10, CreatedDate = DateTime.Now },
                new { Id = 6, Name = "Comics", BookId = 11, CreatedDate = DateTime.Now },
                new { Id = 7, Name = "Computers & Tech", BookId = 12, CreatedDate = DateTime.Now }
            );

            // Borrowing Request List
            modelBuilder.Entity<BorrowRequest>().HasData(
                new { Id = 1, UserId = 1, Status = "Approved", CreatedDate = DateTime.Now },
                new { Id = 2, UserId = 1, Status = "Approved", CreatedDate = DateTime.Now },
                new { Id = 3, UserId = 2, Status = "Waiting", CreatedDate = DateTime.Now },
                new { Id = 4, UserId = 3, Status = "Rejected", CreatedDate = DateTime.Now },
                new { Id = 5, UserId = 4, Status = "Approved", CreatedDate = DateTime.Now }
            );

            // Borrowing Request Detail List
            modelBuilder.Entity<BorrowRequestDetail>().HasData(
                new { Id = 1, BookId = 1, BorrowingRequestId = 1 },
                new { Id = 2, BookId = 2, BorrowingRequestId = 1 },
                new { Id = 3, BookId = 3, BorrowingRequestId = 1 },
                new { Id = 4, BookId = 4, BorrowingRequestId = 1 },
                new { Id = 5, BookId = 5, BorrowingRequestId = 2 },
                new { Id = 6, BookId = 6, BorrowingRequestId = 3 }
            );

            // Role List
            modelBuilder.Entity<Role>().HasData(
                new { Id = 1, UserRoles = "Admin", RoleDescription = "Admin can do the following actions: Viewing/Adding/Updating/Deleting a Category; Viewing/Adding/Updating/Deleting a Book; Viewing the list of borrowing requests; Approving/Rejecting request from Normal User" },
                new { Id = 2, UserRoles = "User", RoleDescription = "User can do the following actions: Borrowing book. One borrowing request can request more than 1 book (maximum is 5 books and 3 borrowing requests in a month); Normal User can see the list of books that he/she already borrowed with status (Approve/Reject/Waiting)" }
            );

            // User List
            modelBuilder.Entity<User>().HasData(
                new { Id = 1, Password = "123456", FirstName = "Manh", LastName = "Nguyen", Age = DateTime.Now.Year - 1997, DateOfBirth = new DateTime(1997, 01, 22), Gender = "Male", Phone = "0123456789", Address = "Ha Noi", Email = "manh@gmail.com", RoleId = 1, CreatedDate = DateTime.Now },
                new { Id = 2, Password = "123456", FirstName = "Tung", LastName = "Tran", Age = DateTime.Now.Year - 1998, DateOfBirth = new DateTime(1998, 02, 23), Gender = "Male", Phone = "0987654321", Address = "Quang Ninh", Email = "tung@gmail.com", RoleId = 2, CreatedDate = DateTime.Now },
                new { Id = 3, Password = "123456", FirstName = "Trang", LastName = "Bui", Age = DateTime.Now.Year - 1999, DateOfBirth = new DateTime(1999, 03, 24), Gender = "Female", Phone = "0123789456", Address = "Ha Noi", Email = "trang@gmail.com", RoleId = 2, CreatedDate = DateTime.Now },
                new { Id = 4, Password = "123456", FirstName = "Thu", LastName = "Nguyen", Age = DateTime.Now.Year - 2000, DateOfBirth = new DateTime(2000, 04, 25), Gender = "Female", Phone = "0456123789", Address = "Ho Chi Minh", Email = "thu@gmail.com", RoleId = 2, CreatedDate = DateTime.Now },
                new { Id = 5, Password = "123456", FirstName = "Hung", LastName = "Nguyen", Age = DateTime.Now.Year - 2001, DateOfBirth = new DateTime(2001, 05, 26), Gender = "Male", Phone = "0789456123", Address = "Nghe An", Email = "hung@gmail.com", RoleId = 2, CreatedDate = DateTime.Now },
                new { Id = 6, Password = "123456", FirstName = "Toan", LastName = "Tran", Age = DateTime.Now.Year - 2002, DateOfBirth = new DateTime(2002, 06, 27), Gender = "Male", Phone = "0789123456", Address = "Da Nang", Email = "toan@gmail.com", RoleId = 2, CreatedDate = DateTime.Now }
            );
        }
        #endregion
    }
}
