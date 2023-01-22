using System;

namespace Lab
{
    public class Program
    {
        public static void Main()
        {
            Book book1 = new Book(1, "Dracula", "Bram Stoker", 1897, 13, 13);
            Console.WriteLine(book1.Name);

            Reader reader1 = new Reader
            {
                Id = 1,
                FullName = "Перникова Елизавета Олеговна"
            };
        }
    }
}