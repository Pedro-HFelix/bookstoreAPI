using System.Text.Json.Serialization;
using bookstoreAPI.Communication.Requests;
using bookstoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace bookstoreAPI.Controllers;

public class BookController : BaseController
{
    private static readonly List<Book> BooksInMemory = [];

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult ListAllBooks()
    {
        return Ok(BooksInMemory);
    }
    
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] CreateBook bookToCreate)
    {
        
        var existsBook = BooksInMemory.Any(
            b => b.Title.Equals(bookToCreate.Title, StringComparison.OrdinalIgnoreCase)
        );

        if (existsBook)
        {
            return Conflict("This book already exists");
        }

        var book = new Book
        {
            Id = BooksInMemory.Any() ? BooksInMemory.Max(b => b.Id) + 1 : 1,
            Title = bookToCreate.Title,
            Author = bookToCreate.Author,
            Gender = bookToCreate.Gender,
            Price = bookToCreate.Price,
            StockQuantity = bookToCreate.StockQuantity ?? 0
        };
        
        BooksInMemory.Add(book);
        foreach (var books in BooksInMemory)
        {
            Console.WriteLine($"Id: {books.Id}, Title: {books.Title}, Author: {books.Author}, Gender: {books.Gender}, Price: {books.Price}, StockQuantity: {books.StockQuantity}");
        }
        return CreatedAtAction(nameof(CreateBook), book);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateBook(int id, [FromBody] CreateBook bookToUpdate)
    {
        var existingBook = BooksInMemory.FirstOrDefault(b => b.Id == id);

        if (existingBook == null)
        {
            return NotFound("Book not found.");
        }

        existingBook.Title = bookToUpdate.Title;
        existingBook.Author = bookToUpdate.Author;
        existingBook.Gender = bookToUpdate.Gender;
        existingBook.Price = bookToUpdate.Price;
        existingBook.StockQuantity = bookToUpdate.StockQuantity ?? existingBook.StockQuantity;

        return NoContent(); 
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook(int id)
    {
        var existingBook = BooksInMemory.FirstOrDefault(b => b.Id == id);

        if (existingBook == null)
        {
            return NotFound("Book not found.");
        }

        BooksInMemory.Remove(existingBook);
        

        return NoContent();
    }

}