using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.LIB
{
    public abstract class Player
    {
        private static Random _random;
        private int _moveCounter;
        protected PlayingArea _playingArea;
        private Position Position { get; }
        public int Row { get => Position.Row; }
        public int Column { get => Position.Column; }
        public virtual bool IsVisible { get; } = true;

        protected Player(PlayingArea playingArea)
        {
            _playingArea = playingArea;
            Position = new Position();
            Move();
        }

        public void Move(Position position)
        {
            Position.Row = position.Row;
            Position.Column = position.Column;
        }

        public virtual void Move()
        {
            Position.Row = _random.Next(_playingArea.Rows);
            Position.Column = _random.Next(_playingArea.Columns);
        }

        internal int GetNumberOfMoves()
        {
            return _moveCounter;
        }

        protected int IncreaseMoveCounter()
        {
            return ++_moveCounter;
        }
    }
}
