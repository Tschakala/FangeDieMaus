using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchTheMouse.GUI
{
    public class GameButton : Button
    {
        internal int Row;
        internal int Column;

        public GameButton(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
