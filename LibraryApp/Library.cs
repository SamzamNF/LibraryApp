using System;

namespace LibraryApp
{
    public class Library
    {
        private List<Book> books = new();
        
        public Library()
        {            
            books = new List<Book>();
            LoadBooksFromFile();
        }

        public List<Book> Books
        {
            get { return books; }
        }

        public void AddBook(Book book)
        {
            books.Add(book);

            string bookData = $"{book.Titel};{book.Forfatter};{book.Isbn}\n";
            File.AppendAllText("library_books.txt", bookData);

            Console.WriteLine($"Bogen '{book.Titel}' er tilføjet og gemt til filen.");
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
            if (found)
            {
                //Opdatere filen efter bogen fjernes fra listen.
                UpdateBookFile();
            }
            else
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
            if (found)
            {
                //Opdatere filen efter bogen fjernes fra listen.
                UpdateBookFile();
            }
            else
            {
                Console.WriteLine("Ingen bog med denne Titel");
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
        //Inti. bøger i konstruktør så de hentes når man kører program
        public void LoadBooksFromFile()
        {
            if (File.Exists("library_books.txt"))
            {
                //Læser alle linjer fra filen og gemmer i et array. Gennemgår derefter hver linje. lines = én bog
                string[] lines = File.ReadAllLines("library_books.txt");
                foreach(string line in lines)
                {
                    //Deler linjen op i titel, forfatter osv ved at splitte ved ';" Sørger for linjen er 3 lang, hvis den er oprettes og tilføjes en ny bog til listen.
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        books.Add(new Book(parts[0], parts[1], parts[2]));
                    }
                }
            }
        }
        //Metode til at opdatere filen med bøger når de slettes
        public void UpdateBookFile()
        {
            List<string> bookData = new();

            foreach (var book in books)
            {
                bookData.Add($"{book.Titel};{book.Forfatter};{book.Isbn}");
            }

            //Overskrider filen med den nye og opdateret liste af bøger
            File.WriteAllLines("library_books.txt", bookData);

            Console.WriteLine("Database opdateret");
        }
    }
}

