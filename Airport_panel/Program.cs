using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Panel.FillPanelList();
            Console.WindowWidth = 150;
            for (;;)
            {
                ConsoleInput.MenuMain();
            }            
        }
    }
}
