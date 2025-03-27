using System;

namespace LibraryApp
{
    public class Book
    {
        private string _titel;
        private string _forfatter;
        private string _isbn;
        public Book(string titel, string forfatter, string isbn)
        {
            // Inti. via Properties her, i stedet for felter. Hvor man ville bruge Fx. _titel, _forfatter og _isbn i stedet for.
            Titel = titel;
            Forfatter = forfatter;
            Isbn = isbn;
        }
        public string Titel
        {
            get { return _titel; } 
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    { _titel = value; }
                }
                else
                {
                    throw new ArgumentException("Feltet kan ikke være tomt");
                }
            }
        }
        public string Forfatter
        {
            get { return _forfatter; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _forfatter = value;
                }
                else
                {
                    throw new ArgumentException("Feltet kan ikke være tomt");
                }
            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _isbn = value;
                }
                else
                {
                    throw new ArgumentException("Feltet kan ikke være tomt, og du skal skrive tal.");
                }

            }
        }
    }
}

