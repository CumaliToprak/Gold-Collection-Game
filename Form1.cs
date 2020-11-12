using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altın_Toplama_Oyunu
{
    public partial class Form1 : Form
    {

        StartGame start;
        public Form1()
        {
            InitializeComponent();
            start = new StartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int boardX = Convert.ToInt32(this.tbxX.Text);
            int boardY = Convert.ToInt32(this.tbxY.Text);
            int altinOrani = Convert.ToInt32(this.tbxAltinOran.Text);
            start.createGameBoard(boardX,boardY, altinOrani);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
