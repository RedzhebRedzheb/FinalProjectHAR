using ConsoleApp20.Bussiness;
using ConsoleApp20.Data;
using ConsoleApp20.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

using System.Linq;

namespace ConsoleApp20.Tests
{
    [TestFixture]
    public class BookBusinessTests
    {
        [Test]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var books = new List<Books>
            {
                new Books {  author = "Author 1", name = "Book 1", price = 10.50m },
                new Books { author = "Author 2", name = "Book 2", price = 15.75m }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Books>>();
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.Provider).Returns(books.Provider);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.Expression).Returns(books.Expression);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.ElementType).Returns(books.ElementType);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            var mockContext = new Mock<Contexts>();
            mockContext.Setup(c => c.Books).Returns(mockDbSet.Object);

            var bookBusiness = new BookBussiness(mockContext.Object);

            // Act
            var result = bookBusiness.GetAllBooks();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Author 1", result[0].author);
            Assert.AreEqual("Book 2", result[1].name);
        }

        [Test]
        public void GetBookById_ReturnsBook()
        {
            // Arrange
            var books = new List<Books>
            {
                new Books { author = "Author 1", name = "Book 1", price = 10.50m },
                new Books { author = "Author 2", name = "Book 2", price = 15.75m }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Books>>();
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.Provider).Returns(books.Provider);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.Expression).Returns(books.Expression);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.ElementType).Returns(books.ElementType);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            var mockContext = new Mock<Contexts>();
            mockContext.Setup(c => c.Books).Returns(mockDbSet.Object);

            var bookBusiness = new BookBussiness(mockContext.Object);

            // Act
            var result = bookBusiness.GetBookById(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Author 2", result.author);
            Assert.AreEqual(15.75m, result.price);
        }

        [Test]
        public void AddNewBook_AddsBook()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Books>>();
            var mockContext = new Mock<Contexts>();
            mockContext.Setup(c => c.Books).Returns(mockDbSet.Object);

            var bookBusiness = new BookBussiness(mockContext.Object);
            var newBook = new Books {  author = "New Author", name = "New Book", price = 20.0m };

            // Act
            bookBusiness.AddNewBook(newBook);

            // Assert
            mockDbSet.Verify(m => m.Add(It.IsAny<Books>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void RemoveBook_RemovesBook()
        {
            // Arrange
            var books = new List<Books>
            {
                new Books {  author = "Author 1", name = "Book 1", price = 10.50m },
                new Books { author = "Author 2", name = "Book 2", price = 15.75m }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Books>>();
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.Provider).Returns(books.Provider);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.Expression).Returns(books.Expression);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.ElementType).Returns(books.ElementType);
            mockDbSet.As<IQueryable<Books>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            var mockContext = new Mock<Contexts>();
            mockContext.Setup(c => c.Books).Returns(mockDbSet.Object);

            var bookBusiness = new BookBussiness(mockContext.Object);

            // Act
            var result = bookBusiness.RemoveBook(2);

            // Assert
            Assert.IsTrue(result);
            mockDbSet.Verify(m => m.Remove(It.IsAny<Books>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}