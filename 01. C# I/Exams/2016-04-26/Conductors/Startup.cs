using System;

namespace Conductors
{
    public class Startup
    {
        private static string ReverseTicketString(string ticket)
        {
            var ticketAsCharArray = ticket.ToCharArray();
            Array.Reverse(ticketAsCharArray);
            var outputTicket = new string(ticketAsCharArray);

            return outputTicket;
        }

        private static int ReplacedTicket(int ticket, int perforator)
        {
            var ticketAsString = Convert.ToString(ticket, 2);
            var perforatorAsString = Convert.ToString(perforator, 2);
            var zeroString = new string('0', perforatorAsString.Length);

            var outputTicket = ReverseTicketString(ticketAsString);

            var newString = outputTicket.Replace(perforatorAsString, zeroString).ToString();
            newString = ReverseTicketString(newString);

            return Convert.ToInt32(newString, 2);
        }

        public static void Main()
        {
            var perforator = int.Parse(Console.ReadLine());
            var numberOfTickets = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTickets; i++)
            {
                var ticket = int.Parse(Console.ReadLine());

                var convertedTicket = ReplacedTicket(ticket, perforator);

                Console.WriteLine(convertedTicket);
            }
        }
    }
}
