using System;
using System.Collections.Generic;
using library2.DB;
using Microsoft.AspNetCore.Mvc;

namespace library2
{

  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAll()
    {
      try
      {
        return Ok(FakeDB.Books);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Book> GetOne(string id)
    {
      try
      {
        Book foundBook = FakeDB.Books.Find(b => b.Id == id);
        if (foundBook == null)
        {
          throw new Exception("Invalid Id");
        }
        return Ok(foundBook);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // [HttpGet("{burgerId}/ingredients")]
    // public ActionResult<Burger> GetIngredients(string burgerId)
    // {

    // }

    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
      try
      {
        FakeDB.Books.Add(newBook);
        return Created($"api/books/{newBook.Id}", newBook);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Book> Edit(string id, [FromBody] Book updatedBook)
    {
      try
      {
        Book bookToUpdate = FakeDB.Books.Find(b => b.Id == id);
        if (bookToUpdate == null)
        {
          throw new Exception("Invalid Id");
        }
        //NOTE if this was not required
        bookToUpdate.Title = updatedBook.Title == null ? bookToUpdate.Title : updatedBook.Title;
        bookToUpdate.Author = updatedBook.Author;
        bookToUpdate.Available = updatedBook.Available;
        return Ok(bookToUpdate);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        Book bookToDelete = FakeDB.Books.Find(b => b.Id == id);
        if (bookToDelete == null)
        {
          throw new Exception("Invalid Id");
        }
        FakeDB.Books.Remove(bookToDelete);
        return Ok("Delorted");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}