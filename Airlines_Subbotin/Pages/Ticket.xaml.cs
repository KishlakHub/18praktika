using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airlines_Subbotin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        public List<TicketContext> AllTickets;
        public Ticket(string From, string To)
        {
            InitializeComponent();
            AllTickets = TicketContext.AllTickets().FindAll(x =>
                (x.From == From && To == "") ||
                (From == "" && x.To == To) ||
                (x.From == From && x.To == To));
            CreateUI();
        }
        public void CreateUI()
        {
            foreach (TicketContext ticket in AllTickets)
            {
                parent.Children.Add(new Element.Item(ticket));
            }
        }
    }
}
