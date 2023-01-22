using System;

namespace Lab
{
    public class Program
    {
        public static void Main()
        {
            string booksPath = Directory.GetCurrentDirectory() + "\\books.csv";
            List<Book> list = TableLoader.LoadBooks(booksPath);

            Console.WriteLine($"{list[1].AuthorName}");
        }
    }
}