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
    public partial class MainFrm : Form
    {

        StartGame start;
        //Bu iki değişkene diğer classlardan daha sonra erişilmek istenecek.
        
        public MainFrm()
        {
            InitializeComponent();
        }

        public static int adımSayisi;
        public static int oyuncuAltinSayisi;
        private void button1_Click(object sender, EventArgs e)
        {
            int boardX = Convert.ToInt32(this.tbxX.Text);
            int boardY = Convert.ToInt32(this.tbxY.Text);
            double altinOrani = Convert.ToDouble(this.tbxAltinOran.Text);
            double gizliAltinOrani = Convert.ToDouble(this.tbxGizliAltin.Text);
            adımSayisi = Convert.ToInt32(this.tbxAdımSayısı.Text);
            oyuncuAltinSayisi = Convert.ToInt32(this.tbxOyuncuAltın.Text);

            start = new StartGame(boardX, boardY, altinOrani, gizliAltinOrani);
            start.createGameBoard();
            
        }

    
    }
}
