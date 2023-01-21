using System;

namespace Lab
{
    internal class Book
    {
        public uint Id { get; }
        public string Name { get; }
        public string AuthorName { get; }
        public uint PublicationYear { get; }
        public uint Bookcase { get;  }
        public uint Bookshelf { get; }

        public Book(uint id, string name, string authorName, uint publicationYear, uint bookcase, uint bookshelf)
        {
            Id = id;
            Name = name;
            AuthorName = authorName;
            PublicationYear = publicationYear;
            Bookcase = bookcase;
            Bookshelf = bookshelf;
        }
    }
}
