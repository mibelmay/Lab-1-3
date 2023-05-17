using System;

namespace Lab
{
    public class Program
    {
        public static void Main()
        {
            List<Book> books = BooksTableLoader.LoadBooks($".\\books.csv", "books.csv");
            List<Reader> readers = ReadersTableLoader.LoadReaders($".\\readers.csv", "readers.csv");
            List<Entry> entries = EntriesTableLoader.LoadEntries($".\\entries.csv", "entries.csv", readers, books);

            Output.DisplayDB(books, readers, entries);
        }
    }
}