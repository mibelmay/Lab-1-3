namespace Lab
{
    internal class Entry
    {
        public Reader Reader;
        public Book Book;
        public DateTime BorrowDate;
        public DateTime? ReturnDate;
    }

    internal class EntryLoader
    {
        public static List<Reader> Readers = new List<Reader>();
        public static List<Book> Books = new List<Book>();
        public static string EntriesFileName;
        public static List<Entry> LoadEntries(string path, string fileName, List<Reader> readers, List<Book> books)
        {
            EntriesFileName = fileName;
            Readers = readers;
            Books = books;
            List<Entry> entries = new List<Entry>();
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(';');
                Reader reader = LoadReader(elements[0], i);
                Book book = LoadBook(elements[1], i);
                DateTime borrowDate = LoadBorrowDate(elements[2], i);
                DateTime? returndate = LoadReturnDate(elements[3], i, borrowDate);
                entries.Add(
                    new Entry
                    {
                        Reader = reader,
                        Book = book,
                        BorrowDate = borrowDate,
                        ReturnDate = returndate
                    });
            }


            return entries;
        }

        public static Reader LoadReader(string element, int i)
        {
            if (!uint.TryParse(element, out uint readerId))
            {
                throw new ArgumentException($"Ошибка в файле {EntriesFileName} в строке {i + 1}: несоответствие типов данных в столбце readerId");
            }
            foreach(Reader reader in Readers)
            {
                if (reader.Id == readerId)
                {
                    return reader;
                }
            }
            throw new ArgumentException($"Ошибка в файле {EntriesFileName} в строке {i + 1}: в базе нет читателя с Id {readerId}");
        }

        public static Book LoadBook(string element, int i)
        {
            if (!uint.TryParse(element, out uint bookId))
            {
                throw new ArgumentException($"Ошибка в файле {EntriesFileName} в строке {i + 1}: несоответствие типов данных в столбце bookId");
            }
            foreach(Book book in Books)
            {
                if (book.Id == bookId)
                {
                    return book;
                }
            }
            throw new ArgumentException($"Ошибка в файле {EntriesFileName} в строке {i + 1}: в базе нет книги с Id {bookId}");
        }

        public static DateTime LoadBorrowDate(string element, int i)
        {
            if (!DateTime.TryParse(element, out DateTime borrowDate) || borrowDate > DateTime.Now)
            {
                throw new ArgumentException($"Ошибка в файле {EntriesFileName} в строке {i + 1}: дата заема книги введена неверно");
            }
            return borrowDate;
        }

        public static DateTime? LoadReturnDate(string element, int i, DateTime borrowDate)
        {
            if (element == "")
            {
                return null;
            }
            if (!DateTime.TryParse(element, out DateTime returnDate) || returnDate > DateTime.Now || returnDate < borrowDate)
            {
                throw new ArgumentException($"Ошибка в файле {EntriesFileName} в строке {i + 1}: дата возврата книги введена неверно");
            }
            return borrowDate;
        }
    }
}
