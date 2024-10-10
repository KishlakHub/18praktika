using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airlines_Subbotin.Models;

namespace Airlines_Subbotin.Classes
{
    public class TicketContext : Ticket
    {
        public TicketContext(int price, string from, string to, DateTime startTime, DateTime endTime) : base(price, from, to, startTime, endTime) { }
        public static List<TicketContext> AllTickets()
        {


            List<TicketContext> allTickets = new List<TicketContext>();
            MySqlConnection connection = WorkingBD.Connection.OpenConnection();
            MySqlDataReader ticketQuery = WorkingBD.Connection.Query("SELECT * FROM `Airlines`.`Tickets`;", connection);
            while (ticketQuery.Read())
            {
                allTickets.Add(new TicketContext(
                    ticketQuery.GetInt32(3),
                    ticketQuery.GetString(1),
                    ticketQuery.GetString(2),
                    ticketQuery.GetDateTime(4),
                    ticketQuery.GetDateTime(5)
                    ));
            }
            WorkingBD.Connection.CloseConnection(connection);
            return allTickets;
        }
    }
}
