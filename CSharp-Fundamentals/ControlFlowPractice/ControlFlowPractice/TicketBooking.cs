namespace ControlFlowPractice
{
    public class TicketBooking
    {
        public static void Run()
        {
            Console.WriteLine("Movie Ticket Booking");


            int availableSeats = 10;


            Console.Write("Enter Tickets: ");
            int requestedTickets =
                Convert.ToInt32(Console.ReadLine());


            if (requestedTickets <= availableSeats)
            {
                availableSeats =
                    availableSeats - requestedTickets;


                Console.WriteLine("Booking Successful");

                Console.WriteLine(
                    "Remaining Seats: " + availableSeats
                );
            }
            else
            {
                Console.WriteLine(
                    "Not enough seats available"
                );
            }
        }
    }
}