using CatchTheMouse.LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(10, 10);

            Console.WriteLine("<---> Fange Die Maus <--->");

            while (true)
            {
                Console.WriteLine("Sie sind dran, geben Sie einen Zug ein: ");
                Console.Write("Row: ");
                int newRow = int.Parse(Console.ReadLine());
                Console.Write("Column: ");
                int newColumn = int.Parse(Console.ReadLine());
                if (game.Play(new Position(newRow - 1, newColumn - 1)))
                {
                    break;
                }
            }
        }
    }
}
