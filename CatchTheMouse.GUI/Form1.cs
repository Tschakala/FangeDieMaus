using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatchTheMouse.LIB;

namespace CatchTheMouse.GUI
{
    public partial class Form1 : Form
    {
        private const int ROWS = 10;
        private const int COLUMNS = 10;
        private GameButton[,] _buttons;
        private Game _game = new Game(ROWS, COLUMNS);
        public Form1()
        {
            _buttons = new GameButton[ROWS, COLUMNS];
            InitializeComponent();


        }

        public void CreateButtons()
        {
            for (int x = 0; x < ROWS; x++)
            {
                for (int y = 0; y < COLUMNS; y++)
                {
                    CreateButton(x, y);
                }
                flw1.SetFlowBreak(_buttons[x, _buttons.GetLength(1) - 1], true);
            }
        }

        public void CreateButton(int row, int column)
        {
            GameButton gb = new GameButton(row, column);

            gb.Width = 84;
            gb.Height = 84;
            gb.BackgroundImage = Properties.Resources.CTM;
            gb.BackgroundImageLayout = ImageLayout.Zoom;
            gb.Click += new System.EventHandler(this.GameButton_Click);
            flw1.Controls.Add(gb);

            _buttons[row, column] = gb;
        }

        private void GameButton_Click(object sender, EventArgs e)
        {

        }
    }
}
