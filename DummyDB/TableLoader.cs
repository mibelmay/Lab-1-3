using System.Runtime.CompilerServices;

namespace Lab
{
    internal class TableLoader
    {
        //создаем листы с айдишниками чтобы следить что они не повторяются 
        public static List<uint>? BookIds = new List<uint>();
        public static List<uint>? ReaderIds = new List<uint>();

        public static List<Book> LoadBooks(string path)
        {
            List<Book> books = new List<Book>();
            string[] lines = File.ReadAllLines(path);

            CheckBooksLines(lines);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(';');
                books.Add(
                    new Book {
                        Id = LoadBookId(elements[0], i),
                        AuthorName = LoadAuthorName(elements[1], i),
                        Name = LoadName(elements[2], i),
                        PublicationDate = LoadPublicationDate(elements[3], i),
                        Bookcase = LoadBookcase(elements[4], i),
                        Bookshelf = LoadBookshelf(elements[5], i),
                    });
            }

            return books;

        }

        public static void CheckBooksLines(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(';').Length != 6)
                {
                    Console.WriteLine("Ошибка: в файле books.json количество столбцов не соответствует заданному");
                    throw new ArgumentException("Проверьте правильность данных в файле");
                }    
            }
        }

        public static uint LoadBookId(string element, int i)
        {
            if(!uint.TryParse(element, out uint bookId))
            {
                throw new ArgumentException($"Ошибка в строке {i + 1}: несоответствие типов данных в столбце Id");
            }
            if (BookIds.Contains(bookId))
            {
                throw new ArgumentException($"Ошибка в строке {i + 1}: повторяющийся Id");
            }
            BookIds.Add(bookId);
            return bookId;
        }

        public static string LoadName(string element, int i)
        {
            if(element == "")
            {
                throw new ArgumentException($"Ошибка в строке {i + 1}: отсутствует название книги");
            }
            return element;
        }

        public static string LoadAuthorName(string element, int i)
        {
            if (element == "")
            {
                throw new ArgumentException($"Ошибка в строке {i + 1}: отсутствует имя автора");
            }
            return element;
        }

        public static DateTime LoadPublicationDate(string element, int i)
        {
            if (!(DateTime.TryParse(element, out DateTime publicDate)) || publicDate > DateTime.Now)
            {
                throw new ArgumentException($"Ошибка в строке {i + 1}: дата публикации книги введена неверно");
            }
            return publicDate;
        }

        public static uint LoadBookcase(string element, int i)
        {
            if (!uint.TryParse(element, out uint bookcase))
            {
                throw new ArgumentException($"Ошибка в строке {i + 1}: номер книжного шкафа введен некорректно");
            }
            return bookcase;
        }

        public static uint LoadBookshelf(string element, int i)
        {
            if (!uint.TryParse(element, out uint bookshelf))
            {
                throw new ArgumentException($"Ошибка в строке {i + 1}: номер книжной полки введен некорректно");
            }
            return bookshelf;
        }
    }
}
