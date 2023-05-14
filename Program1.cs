using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SydneyHotel
{
    class Program
    {
        class ReservationDetail
        {
            public string CustomerName { get; set; }
            public int Nights { get; set; }
            public bool RoomService { get; set; }
            public double TotalPrice { get; set; }
        }
        static double CalculatePrice(int nights, bool hasRoomService)
        {
            double price = 0;
            if ((nights > 0) && (nights <= 3))
                price = 100 * nights;
            else if ((nights > 3) && (nights <= 10))
                price = 80.5 * nights;
            else if ((nights > 10) && (nights <= 20))
                price = 75.3 * nights;
            if (hasRoomService)
                return price + price * 0.1;
            else
                return price;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(".................Welcome to Sydney Hotel...............");
            Console.Write("\nEnter no. of Customer: ");
            int numberOfCustomers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            List<ReservationDetail> reservations = new List<ReservationDetail>();
            for (int i = 0; i < numberOfCustomers; i++)
            {
                ReservationDetail rd = new ReservationDetail();
                Console.Write("Enter customer name: ");
                rd.CustomerName = Console.ReadLine();
                Console.Write("Enter the number of nights: ");
                rd.Nights = Convert.ToInt32(Console.ReadLine());
                while (!(rd.Nights > 0) && (rd.Nights <= 20))
                {
                    Console.Write("Number of nights should be between 1 to 20. Please enter a valid 
                   number: ");
                   
                    rd.Nights = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("Enter yes/no to indicate whether you want a room service: ");
                string hasRoomServiceString = Console.ReadLine();
                rd.RoomService = hasRoomServiceString.ToLower() == "yes";
                rd.TotalPrice = CalculatePrice(rd.Nights, rd.RoomService);
                Console.WriteLine($"The total price from {rd.CustomerName} is ${rd.TotalPrice}\n------------
               --------------------------------------------------------\n");
               
                reservations.Add(rd);
            }
            var minPrice = reservations.Min(x => x.TotalPrice);
            var maxPrice = reservations.Max(x => x.TotalPrice);
            var minRes = reservations.First(x => x.TotalPrice == minPrice);
            var maxRes = reservations.First(x => x.TotalPrice == maxPrice);
            Console.WriteLine("\n\t\t\t\tSummary of reservation");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.WriteLine("Name\t\tNumber of nights\t\tRoom service\t\tCharge");

            Console.WriteLine($"{minRes.CustomerName}\t\t\t{minRes.Nights}\t\t\t{minRes.RoomService}\t\t\
            t{ minRes.TotalPrice}
            ");
       

Console.WriteLine($"{maxRes.CustomerName}\t\t{maxRes.Nights}\t\t\t{maxRes.RoomService}\t\t\t
       { maxRes.TotalPrice}
            ");
        Console.WriteLine("\n--------------------------------------------------------------------\n");
            Console.WriteLine($"The customer spending most is {maxRes.CustomerName} 
${ maxRes.TotalPrice}
            ");
        Console.WriteLine($"The customer spending least is {minRes.CustomerName} 
${ minRes.TotalPrice}
            ");
        Console.WriteLine($"Press any key to continue....");
            Console.ReadKey();
        }
    }
}