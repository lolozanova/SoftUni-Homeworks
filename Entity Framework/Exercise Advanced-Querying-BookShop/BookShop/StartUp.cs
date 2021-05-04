namespace BookShop
{
    using BookShop.Models.Enums;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //int lengthCheck = int.Parse(Console.ReadLine());

            //  var result = GetBooksByAgeRestriction(db, command);

            // Console.WriteLine(result);

            // Console.WriteLine( GetGoldenBooks( db));
            // Console.WriteLine(GetBooksByPrice(db));
            // int year = int.Parse(Console.ReadLine());
            // Console.WriteLine( GetBooksNotReleasedIn(db, year));

            // Console.WriteLine(GetBooksByCategory( db, input));

            //  Console.WriteLine( GetBooksReleasedBefore(db, date));
            // Console.WriteLine(GetAuthorNamesEndingIn(db,  input));
            // Console.WriteLine(  GetBookTitlesContaining( db, input));

            // Console.WriteLine(GetBooksByAuthor(db, input));
            //Console.WriteLine(CountBooks( db, lengthCheck));
            // Console.WriteLine(CountCopiesByAuthor( db));
            // Console.WriteLine(GetTotalProfitByCategory(db));
            // Console.WriteLine(GetMostRecentBooks(db ));

            //IncreasePrices(db);

            Console.WriteLine(RemoveBooks(db));

        }
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                                                .Where(x => x.Copies < 4200)
                                                .ToList();

            context.Books.RemoveRange(booksToDelete);
            context.SaveChanges();
            return booksToDelete.Count ;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                                    .Where(x => x.ReleaseDate.Value.Year < 2010)
                                    .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var bookByCategory = context.Categories
                                        .Select(x => new
                                        {
                                            CategoryName = x.Name,
                                            Books = x.CategoryBooks.Select(b => new
                                            {
                                                b.Book.Title,
                                                b.Book.ReleaseDate.Value
                                            })
                                            .OrderByDescending(b => b.Value)
                                            .Take(3)
                                            .ToArray()
                                        })
                                        .OrderBy(x => x.CategoryName);

            var sb = new StringBuilder();
            foreach (var category in bookByCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            /*Return the total profit of all books by category. Profit for a book can be calculated by multiplying its number of copies by the price per single book. Order the results by descending by total profit for category and ascending by category name.*/

            var booksProfit = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            return String.Join(Environment.NewLine, booksProfit.Select(x => $"{x.Name} ${x.Profit:f2}"));


        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            /*Return the total number of book copies for each author. Order the results descending by total book copies.
Return all results in a single string, each on a new line.*/

            var authors = context.Authors
                .Include(x => x.Books)
                .Select(x => new
                {
                    AuthorName = x.FirstName + ' ' + x.LastName,
                    CountBooks = x.Books.Sum(x => x.Copies)
                }
                )
                .OrderByDescending(x => x.CountBooks)
                .ToList();

            return String.Join(Environment.NewLine, authors.Select(x => $"{x.AuthorName} - {x.CountBooks}"));
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                                .Where(x => x.Title.Length > lengthCheck)
                                .ToList();
            return books.Count();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            /* Return all titles of books and their authors’ names for books, which are written by authors whose last names start with the given string.
 Return a single string with each title on a new row.Ignore casing.Order by book id ascending.*/

            var books = context.Books
                                .Where(x => x.Author.LastName.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                                .Select(x => new
                                {
                                    x.BookId,
                                    BooksTitle = x.Title,
                                    AuthorsName = x.Author.FirstName + ' ' + x.Author.LastName
                                })
                                .OrderBy(x => x.BookId)
                                .ToList();

            return String.Join(Environment.NewLine, books.Select(x => $"{x.BooksTitle} ({x.AuthorsName})"));

        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var targetTitle = input.ToLower();
            var books = context.Books
                                .Where(x => x.Title.ToLower().Contains(targetTitle))
                                .Select(x => x.Title)
                                .OrderBy(x => x)
                                .ToList();

            return String.Join(Environment.NewLine, books);
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var author = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + ' ' + x.LastName)
                .OrderBy(x => x);
            return String.Join(Environment.NewLine, author);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(x => x.ReleaseDate.Value < targetDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate.Value)
;

            var result = String.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));
            return result;
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
            var booksByCategory = context.Books
                                          .Include(x => x.BookCategories)
                                          .ThenInclude(x => x.Category)
                                          .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                                          .Select(x => x.Title)
                                          .OrderBy(x => x)
                                          .ToList();

            return String.Join(Environment.NewLine, booksByCategory);

        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                                .Where(x => x.ReleaseDate.Value.Year != year)
                                .Select(x => new
                                {
                                    x.Title,
                                    x.BookId
                                })
                                .OrderBy(x => x.BookId)
                                .ToList();
            var result = String.Join(Environment.NewLine, books.Select(x => x.Title));
            return result;
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksWithPrice = context.Books
                                        .Where(b => b.Price > 40)
                                        .Select(b => new
                                        {
                                            BookTitle = b.Title,
                                            BookPrice = b.Price
                                        })
                                        .OrderByDescending(x => x.BookPrice)
                                        .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksWithPrice)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var restrictedByAgeBooks = context.Books
                                              .Where(x => x.AgeRestriction == ageRestriction)
                                              .Select(x => x.Title)
                                              .OrderBy(x => x)
                                              .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var book in restrictedByAgeBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                                .Select(x => new
                                {
                                    Title = x.Title,
                                    BookId = x.BookId
                                })
                                .OrderBy(x => x.BookId)
                                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

       
    }
}
