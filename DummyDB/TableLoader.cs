namespace Lab
{
    internal class TableLoader
    {

        public static List<Book> BookReader(string path)
        {
            List<Book> books = new List<Book>();
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                books.Add(
                    new Book {
                        Id = LoadBookId(lines[i]),
                        Name = LoadName(lines[i]),
                        AuthorName = LoadAuthorName(lines[i])
                    });
            }

        }

        public static uint LoadBookId(string line)
        {

        }

        public static string LoadName(string line)
        {

        }

        public static string LoadAuthorName(string line)
        {

        }


    }
}
