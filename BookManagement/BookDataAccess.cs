using System;
using System.Collections.Generic;
using System.IO;

namespace BookManagement
{
    public class BookDataAccess
    {
        private string fileName = "books.txt";
        private string backupFileName = "books_backup.txt";
        public void AddBook(Book book)
        {
            FileStream filestream = new FileStream (fileName,FileMode.Append);
            StreamWriter write = new StreamWriter(filestream);
            write.WriteLine(
                book.id + ", " +
                book.title + ", " +
                book.author + ", " +
                book.price
            );
            write.Close();
            filestream.Close();
        }
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(fileName))
            {
                return books;
            }

            FileStream filestream = new FileStream(fileName,FileMode.Open);
            StreamReader read = new StreamReader(filestream);
            string line = read.ReadLine();
            while(line!=null)
            {
                string[] data = line.Split(',');

                if (data.Length == 4)
                {
                    int id = int.Parse(data[0].Trim());
                    string title = data[1].Trim();
                    string author = data[2].Trim();
                    double price = double.Parse(data[3].Trim());

                    Book book = new Book(id, title, author, price);
                    books.Add(book);
                }
                line = read.ReadLine();
            }

            read.Close();
            filestream.Close();
            return books;
        }
        public Book FindBookById(int idno)
        {
            List<Book> books = GetAllBooks();

            foreach (Book b in books)
            {
                if (b.id == idno)
                {
                    return b;
                }
            }
            return null;
        }
        public void CreateBackup()
        {
            FileStream fs = new FileStream(fileName,FileMode.Open);
            FileStream backup = new FileStream(backupFileName,FileMode.Create);

            byte[] buffer = new byte[1024];

            int bytesRead;

            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                backup.Write(buffer, 0, bytesRead);
            }
            fs.Close();
            backup.Close();
        }
    }
}