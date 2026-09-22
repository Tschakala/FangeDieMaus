using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheMouse.LIB
{
    public class MouseMove
    {
        private static Random _random;
        private static MouseMove[] _allMoves;
        internal int DeltaRow { get; }
        internal int DeltaColumn { get; }

        static MouseMove()
        {
            _random = new Random();
            _allMoves = new MouseMove[]
            {
                new MouseMove(0, -1),  // Left
                new MouseMove(1, -1),  // Down-Left
                new MouseMove(1, 0),   // Down
                new MouseMove(1, 1),   // Down-Right
                new MouseMove(0, 1),   // Right
                new MouseMove(-1, 1),  // Up-Right
                new MouseMove(-1, 0),  // Up
                new MouseMove(-1, -1), // Up-Left
            };
        }
        private MouseMove(int deltaRow, int deltaColumn)
        {
            DeltaRow = deltaRow;
            DeltaColumn = deltaColumn;
        }

        internal static MouseMove GetMove()
        {
            return _allMoves[_random.Next(_allMoves.Length)];
        }
    }
}
