using CP1401_Assignment2_NoGUI.Data;
using System;
using System.Data;
using System.Linq;

namespace CP1401_Assignment2_NoGUI.Database
{
    class Flight_Costs
    {
        DataTable table;

        public Flight_Costs()
        {
            table = new DataTable("flight_costs");
            table.Columns.Add("destination");
            table.Columns.Add("flighttype");
            table.Columns.Add("cost");

            table.Rows.Add(FlightDestination.Cairns, FlightType.OneWay, 250.0);
            table.Rows.Add(FlightDestination.Cairns, FlightType.Return, 400.0);
            table.Rows.Add(FlightDestination.Sydney, FlightType.OneWay, 425.0);
            table.Rows.Add(FlightDestination.Sydney, FlightType.Return, 575.0);
            table.Rows.Add(FlightDestination.Perth, FlightType.OneWay, 510.0);
            table.Rows.Add(FlightDestination.Perth, FlightType.Return, 700.0);
        }

        public double GetFlightCost(FlightDestination destination, FlightType type)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("destination").Equals(destination.ToString()) && row.Field<string>("flighttype").Equals(type.ToString())
                          select row.Field<string>("cost");
            if (results.Count() > 0)
                return Double.Parse(results.First());
            return -1.0;
        }
    }
}
