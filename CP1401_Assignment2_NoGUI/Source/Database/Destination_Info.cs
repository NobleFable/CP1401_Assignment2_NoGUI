using CP1401_Assignment2_NoGUI.Data;
using System;
using System.Data;
using System.Linq;

namespace CP1401_Assignment2_NoGUI.Database
{
    class Destination_Info
    {
        DataTable table;

        public Destination_Info()
        {
            table = new DataTable("destinations_info");
            table.Columns.Add("destination");
            table.Columns.Add("display");
            table.Columns.Add("code");

            table.Rows.Add(FlightDestination.Cairns, "Cairns", "c");
            table.Rows.Add(FlightDestination.Sydney, "Sydney", "s");
            table.Rows.Add(FlightDestination.Perth, "Perth", "p");
        }

        public string GetDisplay(FlightDestination destination)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("destination").Equals(destination.ToString())
                          select row.Field<string>("display");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public string GetCode(FlightDestination destination)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("destination").Equals(destination.ToString())
                          select row.Field<string>("code");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public FlightDestination? GetFlightDestinationFromCode(string code)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("code").Equals(code.ToLower())
                          select row.Field<string>("destination");
            if (results.Count() > 0)
                return (FlightDestination)Enum.Parse(typeof(FlightDestination), results.First());
            return null;
        }
    }
}
