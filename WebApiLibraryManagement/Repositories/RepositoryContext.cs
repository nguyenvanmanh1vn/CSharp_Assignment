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
                new { Id = 1, Title = "Persepolis : The Story of a Childhood", Image = "https://img.thriftbooks.com/api/images/m/2540127da455500c49d0c50c71683b6f38f0b70b.jpg", Status = "Exist", AuthorId = 1, CategoryId = 1, CreatedDate = DateTime.Now },
                new { Id = 2, Title = "Narrative of the Life of Frederick Douglass, an American Slave", Image = "https://img.thriftbooks.com/api/images/m/8303521a462dc3511f365b692830e3e16b370742.jpg", Status = "Borowed", AuthorId = 2, CategoryId = 2, CreatedDate = DateTime.Now },
                new { Id = 3, Title = "Do What You Are : Discover the Perfect Career for You Through the Secrets of Personality Type", Image = "https://img.thriftbooks.com/api/images/m/721d5caa481de1e0b2ac04205606f92cce1adeae.jpg", Status = "Exist", AuthorId = 3, CategoryId = 3, CreatedDate = DateTime.Now },
                new { Id = 4, Title = "Naruto, Vol. 3", Image = "https://img.thriftbooks.com/api/images/m/456fbecc05164ed1e327ff5ee9922475d1e38df0.jpg", Status = "Exist", AuthorId = 4, CategoryId = 4, CreatedDate = DateTime.Now },
                new { Id = 5, Title = "Adobe Photoshop CS3 for Photographers : A Professional Image Editor's Guide to the Creative Use of Photoshop for the Macintosh and PC", Image = "https://img.thriftbooks.com/api/images/m/f1690297c45711d15406be34e5397b6fcf843718.jpg", Status = "Exist", AuthorId = 5, CategoryId = 5, CreatedDate = DateTime.Now },
                new { Id = 6, Title = "The Ayurvedic Cookbook", Image = "https://img.thriftbooks.com/api/images/m/5ac192845cdf424b29b55fbfa03e0db7e0d278ff.jpg", Status = "Exist", AuthorId = 6, CategoryId = 6, CreatedDate = DateTime.Now },
                new { Id = 7, Title = "Elizabeth Zimmermann's Knitter's Almanac", Image = "https://img.thriftbooks.com/api/images/m/d7b2a08125cda604e3ba179b5f2fa64f56ee8583.jpg", Status = "Exist", AuthorId = 7, CategoryId = 7, CreatedDate = DateTime.Now },
                new { Id = 8, Title = "The Ultimate Book of Optical Illusions", Image = "https://m.media-amazon.com/images/I/51788Fh430L._SL350_.jpg", Status = "Exist", AuthorId = 8, CategoryId = 8, CreatedDate = DateTime.Now },
                new { Id = 9, Title = "Understanding the Borderline Mother : Helping Her Children Transcend the Intense, Unpredictable, and Volatile Relationship", Image = "https://img.thriftbooks.com/api/images/m/8007fc770cbec3c2baaa3026595550d44fc907d4.jpg", Status = "Exist", AuthorId = 9, CategoryId = 9, CreatedDate = DateTime.Now },
                new { Id = 10, Title = "Evidence Not Seen: A Woman's Miraculous Faith in the Jungles of World War II", Image = "https://m.media-amazon.com/images/I/415K3VeI3zL._SL350_.jpg", Status = "Exist", AuthorId = 10, CategoryId = 10, CreatedDate = DateTime.Now }
            );

            // Author List
            modelBuilder.Entity<Author>().HasData(
                new { Id = 1, FirstName = "Marjane", LastName = "Satrapi", Gender = "Female", BookId = 1, CreatedDate = DateTime.Now },
                new { Id = 2, FirstName = "Frederick", LastName = "Douglass", Gender = "Male", BookId = 2, CreatedDate = DateTime.Now },
                new { Id = 3, FirstName = "Barbara", LastName = "Barron", Gender = "Female", BookId = 3, CreatedDate = DateTime.Now },
                new { Id = 4, FirstName = "Masashi", LastName = "Kishimoto", Gender = "Male", BookId = 4, CreatedDate = DateTime.Now },
                new { Id = 5, FirstName = "Martin", LastName = "Evening", Gender = "Male", BookId = 5, CreatedDate = DateTime.Now },
                new { Id = 6, FirstName = "Amadea", LastName = "Morningstar", Gender = "Female", BookId = 6, CreatedDate = DateTime.Now },
                new { Id = 7, FirstName = "Elizabeth", LastName = "Zimmermann", Gender = "Female", BookId = 7, CreatedDate = DateTime.Now },
                new { Id = 8, FirstName = "Al", LastName = "Seckel", Gender = "Male", BookId = 8, CreatedDate = DateTime.Now },
                new { Id = 9, FirstName = "Ann", LastName = "Lawson Christine", Gender = "Female", BookId = 9, CreatedDate = DateTime.Now },
                new { Id = 10, FirstName = "Deibler ", LastName = "Rose Darlene", Gender = "Female", BookId = 10, CreatedDate = DateTime.Now }
            );

            // Category List
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Arts & Music", BookId = 1, CreatedDate = DateTime.Now },
                new { Id = 2, Name = "Biographies", BookId = 2, CreatedDate = DateTime.Now },
                new { Id = 3, Name = "Business", BookId = 3, CreatedDate = DateTime.Now },
                new { Id = 4, Name = "Comics", BookId = 4, CreatedDate = DateTime.Now },
                new { Id = 5, Name = "Computers & Tech", BookId = 5, CreatedDate = DateTime.Now },
                new { Id = 6, Name = "Cooking", BookId = 6, CreatedDate = DateTime.Now },
                new { Id = 7, Name = "Education & Reference", BookId = 7, CreatedDate = DateTime.Now },
                new { Id = 8, Name = "Logic & Brain Teaser Books", BookId = 8, CreatedDate = DateTime.Now },
                new { Id = 9, Name = "Health & Fitness", BookId = 9, CreatedDate = DateTime.Now },
                new { Id = 10, Name = "History Books ", BookId = 10, CreatedDate = DateTime.Now }
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
