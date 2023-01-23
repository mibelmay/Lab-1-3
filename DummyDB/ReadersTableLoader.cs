namespace Lab
{
    internal class ReadersTableLoader
    {
        public static List<uint>? ReaderIds = new List<uint>();

        public static string ReadersFileName;

        public static List<Reader> LoadReaders(string path, string fileName)
        {
            List<Reader> readers = new List<Reader>();
            string[] lines = File.ReadAllLines(path);
            ReadersFileName = fileName;
            CheckReaderLines(lines);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(';');
                readers.Add(
                    new Reader {
                        Id = LoadReaderId(elements[0], i),
                        FullName = LoadFullName(elements[1], i)
                    });
            }
            return readers;

        }

        public static void CheckReaderLines(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(';').Length != 2)
                {
                    Console.WriteLine($"Ошибка: в файле {ReadersFileName} количество столбцов не соответствует заданному");
                    throw new ArgumentException("Проверьте правильность данных в файле");
                }
            }
        }

        public static uint LoadReaderId(string element, int i)
        {
            if (!uint.TryParse(element, out uint readerId))
            {
                throw new ArgumentException($"Ошибка в файле {ReadersFileName} в строке {i + 1}: несоответствие типов данных в столбце Id");
            }
            if (ReaderIds.Contains(readerId))
            {
                throw new ArgumentException($"Ошибка в файле {ReadersFileName} в строке {i + 1}: повторяющийся Id");
            }
            ReaderIds.Add(readerId);
            return readerId;
        }

        public static string LoadFullName(string element, int i)
        {
            if (element == "")
            {
                throw new ArgumentException($"Ошибка в файле {ReadersFileName} в строке {i + 1}: отсутствует имя читателя");
            }
            return element;
        }
    }
}
