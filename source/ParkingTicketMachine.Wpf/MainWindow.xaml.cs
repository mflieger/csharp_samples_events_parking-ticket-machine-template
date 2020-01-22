using ParkingTicketMachine.Core;
using System;
using System.Text;
using System.Windows;

namespace ParkingTicketMachine.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, EventArgs e)
        {
            FastClock.Instance.Factor = 360;
            FastClock.Instance.Time = DateTime.Parse("12:00:00");
            FastClock.Instance.IsRunning = true;
            FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
            SlotMachineWindow slotMachine1 = new SlotMachineWindow("Limestrasse", OnTicketReady) { Owner = this};
            slotMachine1.Show();
            SlotMachineWindow slotMachine2 = new SlotMachineWindow("Landstrasse", OnTicketReady) { Owner = this };
            slotMachine2.Show();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            SlotMachineWindow newSlotMachine = new SlotMachineWindow(TextBoxAddress.Text, OnTicketReady) { Owner = this };
        }

        private void Instance_OneMinuteIsOver(object sender, DateTime e)
        {
            Title = $"Parkscheinzentrale, {FastClock.Instance.Time.ToShortTimeString()}";
        }

        private void OnTicketReady(object sender, Ticket ticket)
        {
            string text = $"{ticket.Description}: ";
            AddLineToTextBox(text, ticket.Amount);
        }

        void AddLineToTextBox(string line, int amount)
        {
            StringBuilder text = new StringBuilder(TextBlockLog.Text);
            text.Append("\n");
            text.Append(FastClock.Instance.Time.ToShortTimeString() + " \t ");
            text.Append(line + " \t ");
            text.Append(FastClock.Instance.Time.ToString() + " \t ");
            text.Append($"{amount} Cent");
            TextBlockLog.Text = text.ToString();
        }

    }
}
