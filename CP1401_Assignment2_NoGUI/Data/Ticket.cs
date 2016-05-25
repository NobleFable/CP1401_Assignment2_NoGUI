using System;

namespace CP1401_Assignment2_NoGUI.Data
{
    public struct Ticket
    {
        public String PassengerName;
        public int PassengerAge;
        public FlightType Type;
        public FlightDestination Destination;
        public FlightClass SeatClass;
        public FlightSeat? Seat;
        public double Cost;
    }
}
