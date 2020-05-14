using System.Collections.Generic;

namespace library2.DB
{
  public static class FakeDB
  {
    public static List<Burger> Burgers = new List<Burger>()
    {
      new Burger("D$ Burger", "Its delicious", 5.00m),
      new Burger("Jake Burger", "Bacon Galore", 6.00m),
      new Burger("Mark Burger", "It's mostly just Ham", 7.00m)
    };

    public static List<Book> Books = new List<Book>()
    {
      new Book("Where the Sidewalk Ends", "Shel Silverstein"),
      new Book("The Hobbit", "J.R.R. Tolkie"),
      new Book("The Lion, The Witch, and the Wardrobe", "C.S. Lewis"),
      new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling")
    };
  }
}