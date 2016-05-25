using CP1401_Assignment2_NoGUI.Data;
using System;
using System.Data;
using System.Linq;

namespace CP1401_Assignment2_NoGUI.Database
{
    class FlightType_Info
    {
        DataTable table;

        public FlightType_Info()
        {
            table = new DataTable("flighttypes_info");
            table.Columns.Add("flighttype");
            table.Columns.Add("display");
            table.Columns.Add("code");

            table.Rows.Add(FlightType.OneWay, "One-Way", "o");
            table.Rows.Add(FlightType.Return, "return", "r");
        }

        public string GetDisplay(FlightType type)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("flighttype").Equals(type.ToString())
                          select row.Field<string>("display");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public string GetCode(FlightType type)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("flighttype").Equals(type.ToString())
                          select row.Field<string>("code");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public FlightType? GetFlightTypeFromCode(string code)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("code").Equals(code.ToLower())
                          select row.Field<string>("flighttype");
            if (results.Count() > 0)
                return (FlightType)Enum.Parse(typeof(FlightType), results.First());
            return null;
        }
    }
}
