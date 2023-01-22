using System;

namespace Lab
{
    public class Program
    {
        public static void Main()
        {
            string booksFileName = "books.csv";
            List<Book> books = BooksTableLoader.LoadBooks($".\\{booksFileName}", booksFileName);

            string readersFileName = "readers.csv";
            List<Reader> readers = ReadersTableLoader.LoadReaders($".\\{readersFileName}", readersFileName);
            Console.WriteLine($"{readers[1].FullName}");
        }
    }
}