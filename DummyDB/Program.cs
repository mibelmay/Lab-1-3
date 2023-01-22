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

            string entriesFileName = "entries.csv";
            List<Entry> entries = EntryLoader.LoadEntries($".\\{entriesFileName}", entriesFileName, readers, books);

            Console.Write($"{entries[0].Reader.FullName} читает {entries[0].Book.Name} с {entries[0].BorrowDate}");
        }
    }
}