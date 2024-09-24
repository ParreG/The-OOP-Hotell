using Microsoft.VisualBasic;
using System.Reflection;

namespace The_OOP_Hotell
{
    class HotelBooking
    {
        public string GuesstName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int lengthOfStayInNights;

        public int price;

        public HotelBooking(string guesstName, DateTime startDate, int lengthOfStayInDays)
        {
            GuesstName = guesstName;
            StartDate = startDate.Add(new TimeSpan(15, 0, 0));
            EndDate = startDate.AddDays(lengthOfStayInDays).Date.Add(new TimeSpan(12, 0, 0));
            lengthOfStayInNights = lengthOfStayInDays;

        }

        public int Price(int lengthOfStayInDays)
        {
            price = 1999;
            return lengthOfStayInDays * price;
        }

        public void information()
        {
            Console.WriteLine("Hej och välkommen mr/ms " + GuesstName);
            Console.WriteLine("Du har bokat ditt hotell rum från " + StartDate);
            Console.WriteLine("Till och med: " + EndDate);
            Console.WriteLine("Ditt totala pris per natt är: " + Price(lengthOfStayInNights) + "kr");
        }

        

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkommen till OOP Hotellet.");
            Console.WriteLine("Vad heter du? För/Efternamn");
            string name = Console.ReadLine();

            Console.WriteLine("När vill du boka rum hos oss? Start Datum: ÅÅÅÅ-MM-DD ");
            DateTime startDate;

            while (!DateTime.TryParse (Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Du skrev fel format. Formatet ska vara ÅÅÅÅ-MM-DD: ");
            }

            Console.WriteLine("Hur många dagar vill du stanna hos oss? Skriv antal dagar med nummer ex 12: ");
            int lengthOfDays = Convert.ToInt32(Console.ReadLine());

            HotelBooking booking = new HotelBooking(name, startDate, lengthOfDays);
            booking.information();

            Console.WriteLine("Vill du ändra din bokning? ");
            string updateBooking = Console.ReadLine().ToLower();

            if (updateBooking == "ja")
            {
                Console.WriteLine("Hur många dagar vill du ändra det till? ");
                lengthOfDays = Convert.ToInt32(Console.ReadLine());
                HotelBooking hotelBooking = new HotelBooking(name, startDate, lengthOfDays);
                Console.WriteLine("Nu har vi uppdaterat din bookning. Nedan följer information för din bookning");
                hotelBooking.information();
            }
            else
            {
                Console.WriteLine("Tack för din bokning!");
            }








        }
    }
}
