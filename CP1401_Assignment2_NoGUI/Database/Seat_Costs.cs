using CP1401_Assignment2_NoGUI.Data;
using System;
using System.Data;
using System.Linq;

namespace CP1401_Assignment2_NoGUI.Database
{
    class Seat_Costs
    {
        DataTable table;

        public Seat_Costs()
        {
            table = new DataTable("seat_costs");
            table.Columns.Add("seat", typeof(FlightSeat));
            table.Columns.Add("display", typeof(string));
            table.Columns.Add("code", typeof(string));
            table.Columns.Add("cost", typeof(double));

            table.Rows.Add(FlightSeat.Window, "Window", "w", 75.0);
            table.Rows.Add(FlightSeat.Aisle, "Aisle", "a", 50.0);
            table.Rows.Add(FlightSeat.Middle, "Middle", "m", -25.0);
        }

        public string GetDisplay(FlightSeat seat)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<FlightSeat>("seat") == seat
                          select row.Field<string>("display");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public string GetCode(FlightSeat seat)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("seat").Equals(seat.ToString())
                          select row.Field<string>("code");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public double GetCost(FlightSeat seat)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("seat").Equals(seat.ToString())
                          select row.Field<string>("cost");
            if (results.Count() > 0)
                return Double.Parse(results.First());
            return -1.0;
        }

        public FlightSeat? GetFlightSeatFromCode(string code)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("code").Equals(code.ToLower())
                          select row.Field<string>("seat");
            if (results.Count() > 0)
                return (FlightSeat)Enum.Parse(typeof(FlightSeat), results.First());
            return null;
        }
    }
}
