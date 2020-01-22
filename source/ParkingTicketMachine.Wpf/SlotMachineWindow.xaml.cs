using System;
using System.Windows;
using ParkingTicketMachine.Core;

namespace ParkingTicketMachine.Wpf
{
    /// <summary>
    /// Interaction logic for SlotMachineWindow.xaml
    /// </summary>
    public partial class SlotMachineWindow
    {
        private readonly SlotMachine _slotMachine;
        private string _parkingTime;
        public SlotMachineWindow(string name, EventHandler<Ticket> ticketReady)
        {
            InitializeComponent();
            Title = name;
            _slotMachine = new SlotMachine(name);
            _slotMachine.LogTicket += ticketReady;
        }

        private void ButtonInsertCoin_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCoins.SelectedIndex < 0)
            {
                TextBoxTimeUntil.Text = "Bitte Münzen einwerfen!";
            }
            else
            {
                FastClock.Instance.IsRunning = false;
                int[] coins = { 10, 20, 50, 100, 200 };
                int coin = coins[ListBoxCoins.SelectedIndex];
                //todo
            }
        }

        private void ButtonPrintTicket_Click(object sender, RoutedEventArgs e)
        {
            //todo
            _slotMachine.PrintTicket();
            FastClock.Instance.IsRunning = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            _slotMachine.Cancel();
            FastClock.Instance.IsRunning = true;
            TextBoxTimeUntil.Text = "Abbruch!";
        }

    }
}
