using System;
using System.ComponentModel.DataAnnotations;

namespace library2
{

  public class Book
  {
    [Required]
    [MinLength(5)]
    public string Title { get; set; }
    [Required]
    [MaxLength(140)]
    public string Author  { get; set; }
    [Required]
    public bool Available { get; set; }
    public string Id { get; private set; }

    public Book()
    {
      Id = Guid.NewGuid().ToString();
    }

    public Book(string title, string author)
    {
      Title = title;
      Author  = author ;
      Available = true;
      Id = Guid.NewGuid().ToString();
    }
  }
}