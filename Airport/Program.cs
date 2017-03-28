using System;
using Airport.DAL;
using Airport.View;


namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightsXml.FillPanelList();
            Console.WindowWidth = 150;
            for (;;)
            {
                ConsoleInput.MenuMain();
            }            
        }
    }
}
