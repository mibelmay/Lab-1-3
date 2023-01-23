namespace Lab
{
    internal class Output
    {
        public static void DisplayBooks(List<Book> books, List<Reader> readers, List<Entry> entries)
        {
            Console.WriteLine("Список всех книг:");
            Console.WriteLine();
            foreach (Book book in books)
            {
                Console.Write($"\"{book.Name}\"");
                foreach(Entry entry in entries)
                {
                    if (book == entry.Book && entry.ReturnDate == null)
                    {
                        Console.Write($": читает {entry.Reader.FullName} c {entry.BorrowDate}");
                        break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}