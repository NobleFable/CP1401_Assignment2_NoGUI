using CP1401_Assignment2_NoGUI.Data;
using CP1401_Assignment2_NoGUI.Database;
using CP1401_Assignment2_NoGUI.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CP1401_Assignment2_NoGUI
{
    class Program
    {
        static MockDataSet mockData;

        static void Main(string[] args)
        {
            mockData = new MockDataSet();
            ConsoleHandler consoleApp = new ConsoleHandler();
            consoleApp.Begin();
        }

        public static MockDataSet GetMockData()
        {
            return mockData;
        }
    }
}
