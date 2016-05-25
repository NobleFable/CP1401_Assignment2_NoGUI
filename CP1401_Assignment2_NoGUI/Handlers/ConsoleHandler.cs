using CP1401_Assignment2_NoGUI.Data;
using CP1401_Assignment2_NoGUI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CP1401_Assignment2_NoGUI.Handlers
{
    class ConsoleHandler
    {
        public void Begin()
        {
            Console.Write(Messages.WELCOMING_MESSAGE.ToString());
            VisitorOrder order = new VisitorOrder();
            order.TicketsOrdered = new List<Ticket>();
            order.VisitorName = Console.ReadLine().Trim();
            Console.WriteLine(string.Format(Messages.WELCOME_NAME.ToString(), order.VisitorName));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(Messages.QUESTION_MENU.ToString());
                Console.Write(Messages.QUESTION_PROMPT.ToString());
                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "i":
                        Console.WriteLine(Messages.SYSTEM_INFORMATION.ToString());
                        break;
                    case "o":
                        {
                            Ticket ticket = new Ticket();
                            ticket.PassengerName = GetPassengerName(order.VisitorName);
                            ticket.Type = GetFlightType();
                            ticket.Destination = GetFlightDestination(ticket.Type);
                            ticket.SeatClass = GetFlightClass();
                            ticket.Seat = GetFlightSeat(ticket.SeatClass);
                            ticket.PassengerAge = GetPassengerAge();
                            ticket.Cost = CalculateFare(ticket);
                            order.TicketsOrdered.Add(ticket);
                        }
                        break;
                    case "e":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine(Messages.ERROR_INVALID_MENU_CHOICE.ToString());
                        break;
                }
            }

            if (order.TicketsOrdered.Count() == 0)
                Console.WriteLine(Messages.EXIT_MESSAGE_NO_ORDERS.ToString());
            else
            {
                Console.WriteLine(string.Format(Messages.EXIT_MESSAGE_ORDERS.ToString(), order.VisitorName));
                List<Ticket> orderedTickets = order.TicketsOrdered.OrderBy(o => o.Cost).ToList();
                double totalCost = 0.0;
                foreach (Ticket orderedTicket in orderedTickets)
                {
                    totalCost += orderedTicket.Cost;
                    Console.WriteLine(string.Format(Messages.EXIT_MESSAGE_ORDERS_SUB.ToString(), orderedTicket.Cost));
                }
                Console.WriteLine(string.Format(Messages.EXIT_MESSAGE_ORDERS_END.ToString(), totalCost));
            }
            Console.WriteLine(Messages.EXIT_MESSAGE_ENDING.ToString());
            Console.ReadLine();
        }

        public string GetPassengerName(String visitorName)
        {
            string response = GetResponse(string.Format(Messages.QUESTION_TICKET_HOLDER.ToString(), visitorName), Messages.QUESTION_PROMPT.ToString(), Messages.ERROR_INVALID_MENU_CHOICE.ToString(), @"^(y|s)$");
            if (response.ToLower().Equals("y"))
                return visitorName;
            else
            {
                Console.Write(Messages.QUESTION_PASSENGER_NAME.ToString());
                response = Console.ReadLine().Trim();
                return response;
            }
        }

        public FlightType GetFlightType()
        {
            FlightType_Info data = Program.GetMockData().GetFlightTypeInformation();
            while (true)
            {
                Console.WriteLine(Messages.QUESTION_FLIGHT_TYPE.ToString());
                foreach (FlightType flightType in Enum.GetValues(typeof(FlightType)).Cast<FlightType>())
                {
                    Console.WriteLine(string.Format(Messages.QUESTION_FLIGHT_TYPE_SUB.ToString(), data.GetCode(flightType).ToUpper(), data.GetDisplay(flightType)));
                }
                Console.Write(Messages.QUESTION_PROMPT.ToString());
                string response = Console.ReadLine().Trim();
                FlightType? conversion = data.GetFlightTypeFromCode(response);
                if (conversion != null)
                    return conversion ?? default(FlightType);
                else
                    Console.WriteLine(Messages.ERROR_INVALID_MENU_CHOICE.ToString());
            }
        }

        public FlightDestination GetFlightDestination(FlightType type)
        {
            FlightType_Info dataTypes = Program.GetMockData().GetFlightTypeInformation();
            Destination_Info dataDestinations = Program.GetMockData().GetDestinationInformation();
            Flight_Costs dataFlights = Program.GetMockData().GetFlightCosts();
            while (true)
            {
                Console.WriteLine(string.Format(Messages.QUESTION_DESTINATION.ToString(), dataTypes.GetDisplay(type)));
                foreach (FlightDestination destination in Enum.GetValues(typeof(FlightDestination)).Cast<FlightDestination>())
                {
                    Console.WriteLine(string.Format(Messages.QUESTION_DESTINATION_SUB.ToString(), dataDestinations.GetCode(destination).ToUpper(), dataDestinations.GetDisplay(destination), dataFlights.GetFlightCost(destination, type)));
                }
                Console.Write(Messages.QUESTION_PROMPT.ToString());
                string response = Console.ReadLine().Trim();
                FlightDestination? conversion = dataDestinations.GetFlightDestinationFromCode(response);
                if (conversion != null)
                    return conversion ?? default(FlightDestination);
                else
                    Console.WriteLine(Messages.ERROR_INVALID_MENU_CHOICE.ToString());
            }
        }

        public FlightClass GetFlightClass()
        {
            Class_Costs data = Program.GetMockData().GetClassCosts();
            while (true)
            {
                Console.WriteLine(Messages.QUESTION_FARE.ToString());
                foreach (FlightClass flightClass in Enum.GetValues(typeof(FlightClass)))
                {
                    bool canChooseSeat = data.HasSeatingChoice(flightClass);
                    Console.WriteLine(string.Format(Messages.QUESTION_FARE_SUB.ToString(), data.GetCode(flightClass).ToUpper(), data.GetDisplay(flightClass), data.GetCost(flightClass), 
                        canChooseSeat ? Messages.QUESTION_FARE_CAN_CHOOSE_SEAT : Messages.QUESTION_FARE_CANNOT_CHOOSE_SEAT));
                }
                Console.Write(Messages.QUESTION_PROMPT.ToString());
                string response = Console.ReadLine().Trim();
                FlightClass? conversion = data.GetFlightClassFromCode(response);
                if (conversion != null)
                    return conversion ?? default(FlightClass);
                else
                    Console.WriteLine(Messages.ERROR_INVALID_MENU_CHOICE.ToString());

            }
        }

        public FlightSeat? GetFlightSeat(FlightClass flightClass)
        {
            Class_Costs dataClasses = Program.GetMockData().GetClassCosts();
            Seat_Costs dataSeats = Program.GetMockData().GetSeatCosts();
            if (!dataClasses.HasSeatingChoice(flightClass))
                return null;
            while (true)
            {
                Console.WriteLine(Messages.QUESTION_SEAT.ToString());
                foreach (FlightSeat seat in Enum.GetValues(typeof(FlightSeat)))
                {
                    Console.WriteLine(string.Format(Messages.QUESTION_SEAT_SUB.ToString(), dataSeats.GetCode(seat).ToUpper(), dataSeats.GetDisplay(seat), dataSeats.GetCost(seat)));
                }
                Console.Write(Messages.QUESTION_PROMPT.ToString());
                string response = Console.ReadLine().Trim();
                FlightSeat? conversion = dataSeats.GetFlightSeatFromCode(response);
                if (conversion != null)
                    return conversion;
                else
                    Console.WriteLine(Messages.ERROR_INVALID_MENU_CHOICE.ToString());
            }
        }

        public int GetPassengerAge()
        {
            Age_Discounts data = Program.GetMockData().GetAgeDiscounts();
            StringBuilder question = new StringBuilder();
            question.Append(Messages.QUESTION_AGE.ToString());
            foreach (DiscountData discount in data.GetAllDiscounts())
            {
                question.AppendFormat(Messages.QUESTION_AGE_SUB.ToString(), discount.Display, discount.Comparison == AgeComparison.HIGHER ? "over" : "under", discount.Age, discount.Discount * 100.0);
            }
            string response = GetResponse(question.ToString(), Messages.QUESTION_PROMPT_AGE.ToString(), Messages.ERROR_INVALID_AGE_INPUT.ToString(), @"^([0-9]|[1-9][0-9]|1[0-2][0-9])$");
            return int.Parse(response);
        }

        public double CalculateFare(Ticket ticket)
        {
            double totalCost = 0.0;

            FlightType_Info dataTypes = Program.GetMockData().GetFlightTypeInformation();
            Destination_Info dataDestinations = Program.GetMockData().GetDestinationInformation();
            Flight_Costs dataFlights = Program.GetMockData().GetFlightCosts();
            Class_Costs dataClasses = Program.GetMockData().GetClassCosts();
            Seat_Costs dataSeats = Program.GetMockData().GetSeatCosts();
            Age_Discounts dataDiscounts = Program.GetMockData().GetAgeDiscounts();

            Console.WriteLine(string.Format(Messages.FARE_CALCULATION_HEADER.ToString(), ticket.PassengerName));
            double cost = dataFlights.GetFlightCost(ticket.Destination, ticket.Type);
            totalCost += cost;
            Console.WriteLine(string.Format(Messages.FARE_CALCULATION_BODY.ToString(), 
                string.Format(Messages.FARE_CALCULATION_DESTINATION_SUB.ToString(), dataDestinations.GetDisplay(ticket.Destination), dataTypes.GetDisplay(ticket.Type).ToLower()), 
                cost));
            cost = dataClasses.GetCost(ticket.SeatClass);
            totalCost += cost;
            Console.WriteLine(string.Format(Messages.FARE_CALCULATION_BODY.ToString(), dataClasses.GetDisplay(ticket.SeatClass), cost));
            if (ticket.Seat != null) {
                cost = dataSeats.GetCost(ticket.Seat ?? default(FlightSeat));
                totalCost += cost;
                Console.WriteLine(string.Format(Messages.FARE_CALCULATION_BODY.ToString(), dataSeats.GetDisplay(ticket.Seat ?? default(FlightSeat)), cost));
            }
            DiscountData? discount = dataDiscounts.GetApplicableDiscount(ticket.PassengerAge);
            if (!discount.HasValue)
                Console.WriteLine(string.Format(Messages.FARE_CALCULATION_BODY_AGE.ToString(), "Age",
                    string.Format(Messages.FARE_CALCULATION_AGE_SUB_NO_DISCOUNT.ToString(), ticket.PassengerAge)));
            else
            {
                Console.WriteLine(string.Format(Messages.FARE_CALCULATION_BODY_AGE.ToString(), "Age",
                    string.Format(Messages.FARE_CALCULATION_AGE_SUB_HAS_DISCOUNT.ToString(), ticket.PassengerAge, discount.Value.Display, discount.Value.Discount * 100.0)));
                totalCost *= (1.0 - discount.Value.Discount);
            }
            Console.WriteLine(string.Format(Messages.FARE_CALCULATION_FOOTER.ToString(), Messages.FARE_CALCULATION_FOOTER_SUB.ToString(), totalCost));
            return totalCost;
        }

        public string GetResponse(string question, string prompt, string error, string regex)
        {
            Console.WriteLine(question);
            Console.Write(prompt);
            string response = Console.ReadLine().Trim();
            while (!Regex.Match(response, regex, RegexOptions.IgnoreCase).Success)
            {
                Console.WriteLine(error);
                Console.WriteLine(question);
                Console.Write(prompt);
                response = Console.ReadLine().Trim();
            }
            return response;
        }
    }
}
