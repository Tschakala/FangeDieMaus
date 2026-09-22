using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.LIB
{
    public class Mouse : Player
    {
        //private MouseMove _mouseMove;
        private int _counter = 0;
        public override bool IsVisible 
        { 
            get
            {
                if (_counter % 3 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Mouse(PlayingArea playingArea) : base(playingArea)
        {

        }

        public override void Move()
        {
            while (true)
            {
                MouseMove move = MouseMove.GetMove();

                Position pos = new Position
                {
                    Row = base.Row + move.DeltaRow,
                    Column = base.Column + move.DeltaColumn
                };

                if (_playingArea.IsValid(pos))
                {
                    Move(pos);
                    break;
                }
            }
            _counter++;
        }
    }
}
