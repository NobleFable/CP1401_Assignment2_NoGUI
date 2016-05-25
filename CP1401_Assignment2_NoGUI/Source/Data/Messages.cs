using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP1401_Assignment2_NoGUI.Data
{
    public class Messages
    {
        public static string WELCOMING_MESSAGE = "What is your name? ";
        public static string WELCOME_NAME = "\nWelcome, {0}.\n";

        public static string SYSTEM_INFORMATION = "\nThank you for choosing Tropical Airlines for your air travel needs. You will be asked questions regarding what type of ticket you would like to purchase as well as destination information. We also offer discounts based on age and pensioner status.\n";

        public static string QUESTION_PROMPT = "\nPlease select an option: ";
        public static string QUESTION_PROMPT_AGE = "Please enter the age: ";

        public static string QUESTION_MENU = "\nTropical Airlines Ticket Ordering System - Main Menu\n\n(I) Instructions\n(O) Order Ticket\n(E) Exit";
        public static string QUESTION_TICKET_HOLDER = "\n{0}, is this ticket for:\n\n(Y) You\n(S) Someone else";
        public static string QUESTION_PASSENGER_NAME = "\nPlease enter the name of the person travelling: ";
        public static string QUESTION_FLIGHT_TYPE = "\nIs this a:\n";
        public static string QUESTION_FLIGHT_TYPE_SUB = "({0}) {1} trip";
        public static string QUESTION_DESTINATION = "\nPlease select the destination for your {0} trip. Fare prices are listed below:\n";
        public static string QUESTION_DESTINATION_SUB = "({0}) {1} - {2:C2}";
        public static string QUESTION_FARE = "\nPlease choose the type of fare. Fees are displayed below and are in addition to the basic fare.\n";
        public static string QUESTION_FARE_SUB = "({0}) {1} - {2:C2} ({3})";
        public static string QUESTION_FARE_CAN_CHOOSE_SEAT = "seat choice available";
        public static string QUESTION_FARE_CANNOT_CHOOSE_SEAT = "unable to choose seat";
        public static string QUESTION_SEAT = "\nPlease choose the seat type:\n";
        public static string QUESTION_SEAT_SUB = "({0}) {1} - {2:C2}";
        public static string QUESTION_AGE = "\nHow old is the person travelling? Various discounts are displayed below:\n\n";
        public static string QUESTION_AGE_SUB = "{0} - for ages {1} {2}, receive a {3}% discount\n";

        public static string FARE_CALCULATION_HEADER = "Calculating fare...\n\nTicket for: {0}";
        public static string FARE_CALCULATION_BODY = "{0,20} -     {1:C2}";
        public static string FARE_CALCULATION_BODY_AGE = "{0,20} -     {1}";
        public static string FARE_CALCULATION_FOOTER = "\n{0,20}      {1:C2}\n";
        public static string FARE_CALCULATION_DESTINATION_SUB = "{0} ({1})";
        public static string FARE_CALCULATION_AGE_SUB_HAS_DISCOUNT = "{0} ({1} - {2}% discount)";
        public static string FARE_CALCULATION_AGE_SUB_NO_DISCOUNT = "{0} (not eligible for discounts)";
        public static string FARE_CALCULATION_FOOTER_SUB = "Total price:";

        public static string EXIT_MESSAGE_NO_ORDERS = "\nYou have not ordered any tickets.";
        public static string EXIT_MESSAGE_ORDERS = "\n{0}, you orders are:\n";
        public static string EXIT_MESSAGE_ORDERS_SUB = "- {0:C2}";
        public static string EXIT_MESSAGE_ORDERS_END = "\nYour final total is: {0:C2}\n";
        public static string EXIT_MESSAGE_ENDING = "Thank you for visiting Tropical Airlines. Have a nice day.";

        public static string ERROR_INVALID_MENU_CHOICE = "\nInvalid menu choice.";
        public static string ERROR_INVALID_AGE_INPUT = "\nInvalid age, must be between 0-129.";
    }
}
