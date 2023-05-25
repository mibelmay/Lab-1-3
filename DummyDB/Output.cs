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
            string format = $"| {{0, {maxBookAuthor}}} | {{1, {maxBookName}}} | {{2, {maxReader}}} | {{3, 18}} |";
            //13 - кол-во пробелов + кол-во |
            int tableWidth = maxReader + maxBookName + maxBookAuthor + DateTime.MinValue.ToString().Length + 13;
            DisplayHeader(format, tableWidth);
            string author;
            string bookName;
            string readerName;
            string date;
            for (int i = 0; i < entries.Count; i++)
            {
                author = entries[i].Book.AuthorName;
                bookName = entries[i].Book.Name;
                readerName = entries[i].Reader.FullName;
                if (entries[i].ReturnDate!=null)
                {
                    continue;
                }
                date = entries[i].BorrowDate.ToString();
                Console.WriteLine(String.Format(format, author, bookName, readerName, date));
            }
            Console.WriteLine(new string('-', tableWidth));
        }
        private static void DisplayHeader(string format, int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
            Console.WriteLine(String.Format(format, "Автор", "Название", "Читает", "Взял"));
            Console.WriteLine(new string('-', tableWidth));
        }
    }
}