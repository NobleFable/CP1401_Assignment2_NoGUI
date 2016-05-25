using CP1401_Assignment2_NoGUI.Data;
using System;
using System.Data;
using System.Linq;

namespace CP1401_Assignment2_NoGUI.Database
{
    class Class_Costs
    {
        DataTable table;

        public Class_Costs()
        {
            table = new DataTable("class_costs");
            table.Columns.Add("class");
            table.Columns.Add("display");
            table.Columns.Add("code");
            table.Columns.Add("cost");
            table.Columns.Add("seatingchoice");

            table.Rows.Add(FlightClass.Business, "Business", "b", 275.0, true);
            table.Rows.Add(FlightClass.Economy, "Economy", "e", 25.0, true);
            table.Rows.Add(FlightClass.Frugal, "Frugal", "f", 0.0, false);
        }

        public string GetDisplay(FlightClass classType)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("class").Equals(classType.ToString())
                          select row.Field<string>("display");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public string GetCode(FlightClass classType)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("class").Equals(classType.ToString())
                          select row.Field<string>("code");
            if (results.Count() > 0)
                return results.First();
            return null;
        }

        public double GetCost(FlightClass classType)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("class").Equals(classType.ToString())
                          select row.Field<string>("cost");
            if (results.Count() > 0)
                return Double.Parse(results.First());
            return -1.0;
        }

        public bool HasSeatingChoice(FlightClass classType)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("class").Equals(classType.ToString())
                          select row.Field<string>("seatingchoice");
            if (results.Count() > 0)
                return Boolean.Parse(results.First());
            return false;
        }

        public FlightClass? GetFlightClassFromCode(string code)
        {
            var results = from row in table.AsEnumerable()
                          where row.Field<string>("code").Equals(code.ToLower())
                          select row.Field<string>("class");
            if (results.Count() > 0)
                return (FlightClass)Enum.Parse(typeof(FlightClass), results.First());
            return null;
        }
    }
}
