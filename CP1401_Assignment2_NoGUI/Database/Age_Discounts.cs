using CP1401_Assignment2_NoGUI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CP1401_Assignment2_NoGUI.Database
{
    class Age_Discounts
    {
        DataTable table;

        public Age_Discounts()
        {
            table = new DataTable("age_discounts");
            table.Columns.Add("age", typeof(int));
            table.Columns.Add("checker", typeof(AgeComparison));
            table.Columns.Add("display", typeof(string));
            table.Columns.Add("discount", typeof(double));

            table.Rows.Add(2, AgeComparison.LOWER, "Infant Fare Discount", 1.0);
            table.Rows.Add(16, AgeComparison.LOWER, "Child Fare Discount", 0.5);
            table.Rows.Add(65, AgeComparison.HIGHER, "Pensioner Fare Discount", 0.2);
        }

        public List<DiscountData> GetAllDiscounts()
        {
            var results = from row in table.AsEnumerable()
                          select row;
            List<DiscountData> discounts = new List<DiscountData>();
            foreach (DataRow result in results)
                discounts.Add(GetAsDiscountData(result));
            return discounts;
        }

        public DiscountData? GetApplicableDiscount(int age)
        {
            var results = from row in table.AsEnumerable()
                          where (row.Field<int>("age") > age && row.Field<AgeComparison>("checker") == AgeComparison.LOWER) ||
                                (row.Field<int>("age") < age && row.Field<AgeComparison>("checker") == AgeComparison.HIGHER)
                          select row;
            if (results.Count() > 0)
                return GetAsDiscountData(results.First());
            return null;
        }

        public DiscountData GetAsDiscountData(DataRow row)
        {
            DiscountData data = new DiscountData();
            data.Age = row.Field<int>("age");
            data.Comparison = row.Field<AgeComparison>("checker");
            data.Display = row.Field<string>("display");
            data.Discount = row.Field<double>("discount");

            return data;
        }
    }
}
