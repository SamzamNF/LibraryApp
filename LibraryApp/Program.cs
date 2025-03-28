namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n---- Adminstrer Biblotek ----");
                Console.WriteLine("1. Tilføj bog");
                Console.WriteLine("2. Slet bog");
                Console.WriteLine("3. Vis alle bøger");
                Console.WriteLine("4. Afslut program");
                Console.Write("Indtast valg: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BookInput(library);
                        break;
                    case "2":
                        Console.WriteLine("\n1. For at slette med Titel: ");
                        Console.WriteLine("2. For at slette med ISBN: ");
                        Console.Write("Indtast valg: ");
                        string deleteOption = Console.ReadLine();
                        switch (deleteOption)
                        {
                            case "1":
                                Console.Write("Bogens titel som du vil slette: ");
                                string bookName = Console.ReadLine();
                                library.RemoveBookByName(bookName);
                                Console.WriteLine("\nTryk enter for at gå tilbage til menuen..");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "2":
                                Console.Write("Bogens ISBN som du vil slette: ");
                                string isbnNumber = Console.ReadLine();
                                library.RemoveBookByIsbn(isbnNumber);
                                Console.WriteLine("\nTryk enter for at gå tilbage til menuen..");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                        break;
                    case "3":
                        library.PrintBooks();
                        Console.Write("\nVil du sortere bøgerne? (ja/nej): ");
                        string printChoice = Console.ReadLine().ToLower();
                        if (printChoice == "ja" || printChoice == "yes")
                        {
                            library.PrintBooksSortByName();
                        }
                        else
                        {
                            Console.WriteLine("Bøger sorteres ikke.");
                        }
                        Console.WriteLine("\nTryk enter for at gå tilbage til menuen..");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                        running = false;
                        break;
                }
            }
        }
        static void BookInput(Library library)
        {
            Console.Write("\nBogens Titel: ");
            string titel = Console.ReadLine();
            Console.Write("Bogens Forfatter: ");
            string forfatter = Console.ReadLine();
            Console.Write("Bogens ISBN: ");
            string isbn = Console.ReadLine();

            try
            {
                Book newBook = new Book(titel, forfatter, isbn);
                library.AddBook(newBook);
                Console.WriteLine("Bogen er tilføjet");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
            }
        }

    }
}
