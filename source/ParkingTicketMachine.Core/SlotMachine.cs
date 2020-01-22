using System;

namespace ParkingTicketMachine.Core
{
    public class SlotMachine
    {
        private Ticket _ticket;

        public EventHandler<Ticket> LogTicket;
        public string Location { get; private set; }
        public int CoinPouch { get; private set; }
        public int ParkingTime { get; private set; }

        public SlotMachine(string location)
        {
            Location = location;
            CoinPouch = 0;
            ParkingTime = 0;
        }

        public DateTime InsertCoin(int coin)
        {
            DateTime parkDuration = FastClock.Instance.Time;
            FastClock.Instance.IsRunning = false;
            CoinPouch += coin;

            if(CoinPouch >= 50 && CoinPouch < 100)
            {
                parkDuration = parkDuration.AddHours(0.5);
            }
            else if(CoinPouch >= 100 && CoinPouch < 150)
            {
                parkDuration = parkDuration.AddHours(1.0);
            }
            else if(CoinPouch >= 150)
            {
                parkDuration = parkDuration.AddHours(1.5);
            }

            return parkDuration;
        }

        public void PrintTicket()
        {
            _ticket = new Ticket();
            _ticket.Description = Location;
            _ticket.Amount = CoinPouch;
            CoinPouch = 0;
            LogTicket?.Invoke(this, _ticket);
        }

        public void Cancel()
        {
            CoinPouch = 0;
        }


    }
}
