using System;

namespace LibraryApp
{
    public class Library
    {
        private List<Book> books = new();
        
        public Library()
        {
            books = new List<Book>
            {
                new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"),
                new Book("1984", "George Orwell", "9780451524935"),
                new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488"),
                new Book("Pride and Prejudice", "Jane Austen", "9781503290563"),
                new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"),
                new Book("Moby-Dick", "Herman Melville", "9781503280786"),
                new Book("War and Peace", "Leo Tolstoy", "9781400079988"),
                new Book("The Brothers Karamazov", "Fyodor Dostoevsky", "9780374528379"),
                new Book("The Hobbit", "J.R.R. Tolkien", "9780547928227"),
                new Book("Les Misérables", "Victor Hugo", "9780451419439"),
                new Book("Kongens Fald", "Johannes V. Jensen", "9788763813639"),
                new Book("Den Kroniske Uskyld", "Hans-Jørgen Nielsen", "9788702158040"),
                new Book("Harry Potter og De Vises Sten", "J.K. Rowling", "9788771202771"),
                new Book("Lykke-Per", "Henrik Pontoppidan", "9788763803159"),
                new Book("Høsten", "Bjarne Reuter", "9788740031259"),
                new Book("Den Store Gatsby", "F. Scott Fitzgerald", "9788702146580"),
                new Book("Pigen der legede med ilden", "Stieg Larsson", "9788759517236"),
                new Book("Frøken Smillas fornemmelse for sne", "Peter Høeg", "9788702049072")

            };
        }

        public List<Book> Books
        {
            get { return books; }
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBookByName(string bookName)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Titel == bookName)
                {
                    books.RemoveAt(i);
                    Console.WriteLine($"Titel: {bookName} blev slettet");
                    found = true;
                    i--; // Minus med 1, fordi en bog er fundet.
                }
            }
            if (!found)
            {
                Console.WriteLine("Ingen bog med denne Titel");
            }

        }
        public void RemoveBookByIsbn(string isbnNumber)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Isbn == isbnNumber)
                {
                    books.RemoveAt(i);
                    Console.WriteLine($"ISBN: {isbnNumber} blev slettet");
                    found = true;
                    i--; // Minus med 1, fordi en bog er fundet.
                }
            }
            if (!found)
            {
                Console.WriteLine("Ingen bog med dette ISBN");
            }
        }

        public void PrintBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Der er ingen bøger i bibloteket");
                return;
            }

            string infoHeader = string.Format("\n{0,-40} {1,-25} {2,-15}", "Titel", "Forfatter", "ISBN");
            Console.WriteLine(infoHeader);

            foreach (var book in books)
            {
                string printInfo = string.Format("{0,-40} {1,-25} {2,-15}", book.Titel, book.Forfatter, book.Isbn);
                Console.WriteLine(printInfo);
            }
        }
        public void PrintBooksSortByName()
        {
            books.Sort((x, y) => string.Compare(x.Titel, y.Titel));

            string infoHeader = string.Format("\n{0,-40} {1,-25} {2,-15}", "Titel", "Forfatter", "ISBN");
            Console.WriteLine(infoHeader);

            foreach (var book in books)
            {
                string printInfo = string.Format("{0,-40} {1,-25} {2,-15}", book.Titel, book.Forfatter, book.Isbn);
                Console.WriteLine(printInfo);
            }
        }
    }
}

