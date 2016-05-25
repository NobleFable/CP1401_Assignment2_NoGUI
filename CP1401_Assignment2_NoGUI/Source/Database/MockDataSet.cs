namespace CP1401_Assignment2_NoGUI.Database
{
    class MockDataSet
    {
        FlightType_Info flightTypeInfo;
        Destination_Info destinationInfo;
        Flight_Costs flightCosts;
        Class_Costs classCosts;
        Seat_Costs seatCosts;
        Age_Discounts ageDiscounts;

        public MockDataSet()
        {
            flightTypeInfo = new FlightType_Info();
            destinationInfo = new Destination_Info();
            flightCosts = new Flight_Costs();
            classCosts = new Class_Costs();
            seatCosts = new Seat_Costs();
            ageDiscounts = new Age_Discounts();
        }

        public FlightType_Info GetFlightTypeInformation()
        {
            return flightTypeInfo;
        }

        public Destination_Info GetDestinationInformation()
        {
            return destinationInfo;
        }

        public Flight_Costs GetFlightCosts()
        {
            return flightCosts;
        }

        public Class_Costs GetClassCosts()
        {
            return classCosts;
        }

        public Seat_Costs GetSeatCosts()
        {
            return seatCosts;
        }

        public Age_Discounts GetAgeDiscounts()
        {
            return ageDiscounts;
        }
    }
}
