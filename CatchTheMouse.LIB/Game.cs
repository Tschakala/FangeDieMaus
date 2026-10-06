using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatchTheMouse.LIB
{
    public class Game
    {
        private static Random _rng = new Random();
        private PlayingArea _playingArea;
        public Player Mouse { get; }
        public Player Cat { get; }
        public bool GameOver 
        { 
            get
            {
                if (Mouse.Row == Cat.Row && Mouse.Column == Cat.Column)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Game(int rows, int columns)
        {
            _playingArea = new PlayingArea(rows, columns);
            Mouse = new Mouse(_playingArea);
            Cat = new Cat(_playingArea);
        }

        public bool Play(Position catPosition)
        {
            Cat.Move(catPosition);
            Mouse.Move();
            if (GameOver)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Play(Position catPosition ,bool Konsole = true)
        {
            while (true)
            {
                if (_playingArea.IsValid(catPosition))
                {
                    Cat.Move(catPosition);
                    break;
                }
                Console.WriteLine("Der gewünschte Spielzug ist ungültig, bitte geben Sie einen neuen Spielzug ein!");
                Console.Write("Row: ");
                int newRow = int.Parse(Console.ReadLine());
                Console.Write("Column: ");
                int newColumn = int.Parse(Console.ReadLine());
                catPosition = new Position(newRow, newColumn);
            }
            if (GameOver)
            {
                Console.WriteLine("Glückwunsch Sie haben gewonnen!");
                // gewonnen
                return true;
            }
            Console.WriteLine("Die Maus bewegt sich...");
            Thread.Sleep(_rng.Next(500, 1500));
            Mouse.Move();
            printArea(Mouse.IsVisible);
            return false;
        }

        private void printArea(bool v)
        {
            if (v)
            {
                for (int i = 0; i < _playingArea.Rows; i++)
                {
                    for (int j = 0; j < _playingArea.Columns; j++)
                    {
                        if (Mouse.Column == i && Mouse.Row == j)
                        {
                            Console.Write("| ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M ");
                            Console.ResetColor();
                        }
                        else if (Cat.Column == i && Cat.Row == j)
                        {
                            Console.Write("| ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("K ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("|   ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < _playingArea.Rows; i++)
                {
                    for (int j = 0; j < _playingArea.Columns; j++)
                    {
                        if (Cat.Column == i && Cat.Row == j)
                        {
                            Console.Write("| ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("K ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("|   ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
