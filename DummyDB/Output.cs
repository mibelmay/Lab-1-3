using System.Reflection.Metadata;

namespace Lab
{
    class Output
    {
        public static void DisplayBooks(List<Book> books, List<Reader> readers, List<Entry> entries)
        {
            Console.WriteLine("Список книг в библиотеке:");
            Console.WriteLine();
            foreach (Book book in books)
            {
                Console.Write($"\"{book.Name}\", {book.AuthorName}");
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

        public static void DisplayDB(List<Book> books, List<Reader> readers, List<Entry> entries)
        {
            int maxBookAuthor = books.Max(book => book.AuthorName.Length);
            int maxBookName = books.Max(book => book.Name.Length);
            int maxReader = readers.Max(reader => reader.FullName.Length);
            int maxDate = DateTime.MinValue.ToString().Length;
            string format = $"| {{0, {maxBookAuthor}}} | {{1, {maxBookName}}} | {{2, {maxReader}}} | {{3, {maxDate}}} |";
            int tableWidth = maxReader + maxBookName + maxBookAuthor + maxDate + 13;
            DisplayHeader(format, tableWidth);

            for (int i = 0; i < entries.Count; i++)
            {
                WriteTable(entries, i, format);
            }
            Console.WriteLine(new string('-', tableWidth));
        }

        private static void DisplayHeader(string format, int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
            Console.WriteLine(String.Format(format, "Автор", "Название", "Читает", "Взял"));
            Console.WriteLine(new string('-', tableWidth));
        }

        private static void WriteTable(List<Entry> entries, int i, string format)
        {
            string author = entries[i].Book.AuthorName;
            string bookName = entries[i].Book.Name;
            string readerName = entries[i].Reader.FullName;
            if (entries[i].ReturnDate != null)
            {
                return;
            }
            string date = entries[i].BorrowDate.ToString();
            Console.WriteLine(String.Format(format, author, bookName, readerName, date));
        }
    }
}