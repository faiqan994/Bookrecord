using System;
using System.Collections.Generic;
using System.IO;

namespace BookManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            BookDataAccess dataAccess = new BookDataAccess();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("       BOOK MANAGEMENT SYSTEM");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Find Book by ID");
                Console.WriteLine("4. Create Backup");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddBook(dataAccess);
                        break;

                    case "2":
                        ViewAllBooks(dataAccess);
                        break;

                    case "3":
                        FindBook(dataAccess);
                        break;

                    case "4":
                        CreateBackup(dataAccess);
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Program terminated.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void AddBook(BookDataAccess dataAccess)
        {
            Console.Write("Enter Book ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Book Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Book Price: ");
            double price = double.Parse(Console.ReadLine());
            Book book = new Book(id, title, author, price);

            dataAccess.AddBook(book);
            Console.WriteLine("Book added successfully.");
        }
        static void ViewAllBooks(BookDataAccess dataAccess)
        {
            List<Book> books = dataAccess.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }
            Console.WriteLine("========== ALL BOOKS ==========");
            foreach (Book book in books)
            {
                book.Displayinfo();
            }
        }
        static void FindBook(BookDataAccess dataAccess)
        {
            Console.Write("Enter Book ID to search: ");
            int id = int.Parse(Console.ReadLine());

            Book book = dataAccess.FindBookById(id);

            if (book != null)
            {
                Console.WriteLine("Book found:");
                book.Displayinfo();
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        static void CreateBackup(BookDataAccess dataAccess)
        {
            try
            {
                dataAccess.CreateBackup();
                Console.WriteLine("Backup created successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Books file does not exist.");
            }
        }
    }
}