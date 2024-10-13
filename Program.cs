using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System
{
    class Program
    {
        // Book class represents a book in the library
        public class Book
        {
          public string Title { get; set; }
        public string Author { get; set; }
               public bool IsAvailable { get; set; }

            // Constructor to initialize book's properties
            public Book(string title, string author)
            {
                Title = title;
                Author = author;
                IsAvailable = true; // Newly added books are available by default
            }

            // Override ToString method to display book details
            public override string ToString()
            {
                return $"{Title} by {Author} - {(IsAvailable ? "Available" : "Checked Out")}";
            }
        }

        // Member class representing a library member
        public class Member
        {
           public string Name { get; set; }
            public int StudNumber { get; set; }

            // Constructor to initialize member properties
            public Member(string name, int studNumber)
            {
                Name = name;
                StudNumber = studNumber;
            }

            // Override ToString method to display member details
            public override string ToString()
            {
                return $"{Name} (Student Number: {StudNumber})";
            }
        }

        // Library class manages books and members
        public class Library
        {
            private List<Book> books = new List<Book>();
            private List<Member> members = new List<Member>();

            // Method to add a book to the library
            public void AddBook(Book book)
            {
                books.Add(book);
            }

            // Method to add a member to the library
            public void AddMember(Member member)
            {
                members.Add(member);
            }

            // Method to checkout a book by title and member's student number
            public void CheckoutBook(string title, int studNumber)
            {
                // Find the book by title and check if it's available
                var book = books.FirstOrDefault(b => b.Title == title && b.IsAvailable);
                // Find the member by student number
                var member = members.FirstOrDefault(m => m.StudNumber == studNumber);

                // Check if the book is still available
                if (book == null)
                {
                    Console.WriteLine("Thw Book is not available!");
                    return;
                }

                // Check if the member exists
                if (member == null)
                {
                    Console.WriteLine("Member not found!");
                    return;
                }

                // Mark the book as checked out
                book.IsAvailable = false;
                Console.WriteLine($"{member.Name} checked out \"{book.Title}\".");
            }

            // Method to return a book by title
            public void bookReturn(string title)
            {
                // Find the book by title and check if it's checked out
                var book = books.FirstOrDefault(b => b.Title == title && !b.IsAvailable);

                // Check if the book is found and currently checked out
                if (book == null)
                {
                    Console.WriteLine("Book has not been found or already available.");
                    return;
                }

                // Mark the book as available
                book.IsAvailable = true;
                Console.WriteLine($"\"{book.Title}\" has been returned.");
            }

            // Method to display all books in the library
            public void DisplayBooks()
            {
                Console.WriteLine("Library Books:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }

            // Method to display all members of the library
            public void DisplayMembers()
            {
                Console.WriteLine("Library Members:");
                foreach (var member in members)
                {
                    Console.WriteLine(member);
                }
            }
        }

        static void Main(string[] args)
        {
            // Create an instance of the Library class
            Library library = new Library();

            // Add some books to the library
            library.AddBook(new Book("Harry Potter", "J.K Rowling"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald"));

            // Adding members to the library
            library.AddMember(new Member("Alex Jones", 402105100));
            library.AddMember(new Member("Arthur Morgan", 402105101));

            // Display the initial state of books and members
            library.DisplayBooks();
            library.DisplayMembers();

            // Simulate a member checking out a book
            library.CheckoutBook("Harry Potter", 402105100);

            // Display the state of books after checkout
            library.DisplayBooks();

            // Simulate returning a book
            library.ReturnBook("Harry Potter");

            // Display the state of books after they have been returned;
            library.DisplayBooks();
        }
    }

}