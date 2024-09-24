using Microsoft.VisualBasic;
using System.Reflection;

namespace The_OOP_Hotell
{
    class Person
    {
        public string[] GuesstName { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public Person(string[] guesstName, string email, string tel)
        {
            GuesstName = guesstName;
            Email = email;
            Tel = tel;
        }
    }
    class HotelBooking
    {
        public Person Person { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int lengthOfStayInNights;

        public double price;

        public HotelBooking (Person person, DateTime startDate, int lengthOfStayInDays)
        {
            Person = person;
            StartDate = startDate.Add(new TimeSpan(15, 0, 0));
            EndDate = startDate.AddDays(lengthOfStayInDays).Date.Add(new TimeSpan(12, 0, 0));
            lengthOfStayInNights = lengthOfStayInDays;

        }

        public double Price(int lengthOfStayInDays)
        {
            price = 1999;
            if (lengthOfStayInDays < 8 && lengthOfStayInDays > 5)
            {
                price = price * 0.9;
            }
            else if (lengthOfStayInDays < 10)
            {
                price = price * 0.8;
            }
            else if (lengthOfStayInDays < 18)
            {
                price = price * 0.6;
            }
            else
            {
                price = price * 0.5;
            }

            return lengthOfStayInDays * price;
        }

        public void information()
        {
            Console.WriteLine("Hej och välkommen mr/ms " + Person.GuesstName[0] + ", " + Person.Tel + ", " + Person.Email);
            Console.WriteLine("Du har bokat ett rum för följande namn: ");
            foreach ( var name in Person.GuesstName)
            {
                Console.WriteLine(name + ".");
            }
            
            Console.WriteLine("Ditt rum är bokat från " + StartDate);
            Console.WriteLine("Till och med: " + EndDate);
            Console.WriteLine("Ditt totala pris är " + Price(lengthOfStayInNights) + "kr");
            Console.WriteLine();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkommen till OOP Hotellet.");
            Console.WriteLine("Hur många gäster vill du boka rum för? ");
            int numberOfGuests = Convert.ToInt32(Console.ReadLine());

            string[] names = new string[numberOfGuests];

            Console.WriteLine("Nu ska du få skria namn får alla gäster. Första namnet du skriver in ska vara namnet för bokningen!");
            for (int i = 0; i < numberOfGuests; i++)
            {
                Console.WriteLine($"Skriv namn på gäst nummer {i+1}");
                names[i] = Console.ReadLine();
            }
 
            Console.WriteLine("Skriv in ett mejladress för bookningen: ");
            String mejl = Console.ReadLine();

            Console.WriteLine("skriv in ditt telefonnummer: ");
            string tel = Console.ReadLine();

            Person guest = new Person(names, mejl, tel);


            Console.WriteLine("När vill du boka rum hos oss? Start Datum: ÅÅÅÅ-MM-DD ");
            DateTime startDate;

            while (!DateTime.TryParse (Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Du skrev fel format. Formatet ska vara ÅÅÅÅ-MM-DD: ");
            }

            Console.WriteLine("Hur många dagar vill du stanna hos oss? Skriv antal dagar med nummer ex 12: ");
            int lengthOfDays = Convert.ToInt32(Console.ReadLine());

            HotelBooking booking = new HotelBooking(guest, startDate, lengthOfDays);
            booking.information();

            Console.WriteLine("Vill du ändra din bokning? ");
            string updateBooking = Console.ReadLine().ToLower();

            if (updateBooking == "ja")
            {
                Console.WriteLine("Hur många dagar vill du ändra det till? ");
                lengthOfDays = Convert.ToInt32(Console.ReadLine());
                HotelBooking hotelBooking = new HotelBooking(guest, startDate, lengthOfDays);
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
