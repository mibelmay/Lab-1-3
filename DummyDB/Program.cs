using System;

namespace Lab
{
    public class Program
    {
        public static void Main()
        {
            //string booksPath = Directory.GetCurrentDirectory() + "\\books.csv";
            string booksFileName = "books.csv";
            List<Book> list = TableLoader.LoadBooks($".\\{booksFileName}", booksFileName);

            Console.WriteLine($"{list[3].Name}");
        }
    }
}