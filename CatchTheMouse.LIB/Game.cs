using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.LIB
{
    public class Game
    {
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
            Mouse.Move();
            Console.WriteLine(Mouse.Row);
        }

        public void Play(Position catPosition)
        {
            
        }
    }
}
