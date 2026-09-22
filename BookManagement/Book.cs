using System;

namespace BookManagement
{
    public class Book
    {
        public int id {get;set;}
        public string title {get;set;}
        public string author {get;set;}
        public double price {get;set;}

        public Book(int i, string t, string a, double p)
        {
            id = i;
            title = t;
            author = a;
            price = p;
        }
        public void Displayinfo()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Price: " + price);
        }
    }
}