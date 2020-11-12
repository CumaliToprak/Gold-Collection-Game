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
    public partial class frmCreateBoard : Form
    {
        const int X=10, Y=10; //bloklar biraz sağdan başlaması için
        int _boardX, _boardY, _altinOrani;
        List<Kordinat> _altinKonumlari;

        private void frmCreateBoard_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;

            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

        }

        public frmCreateBoard(int boardX, int boardY, int altinOrani, List<Kordinat> altinKonumlari)
        {
            _boardX = boardX;
            _boardY = boardY;
            _altinOrani = altinOrani;
            _altinKonumlari = altinKonumlari;
        }

        private Panel[,] _boardPanels;
        
        public void create() {
            const int boyut = 20;
            var clr1 = Color.Gold;
            var clr2 = Color.DarkGray;

            _boardPanels = new Panel[_boardX, _boardY];


            for (var n = 0; n < _boardX; n++)
            {
                for (var m = 0; m < _boardY; m++)
                {
                    //yeni panel oluşturulur.
                    var newPanel = new Panel
                    {
                        Size = new Size(boyut, boyut),
                        BorderStyle = BorderStyle.Fixed3D,
                        Location = new Point(X + boyut * n, Y + boyut * m),
                        AutoSize = true
                    };
                    
                    // Oluşturulan paneli görüntülemek için Form control'e eklenir
                    Controls.Add(newPanel);
                    // add to our 2d array of panels for future use
                    _boardPanels[n, m] = newPanel;

                    // color the backgrounds
                    if (_altinKonumlari.FindIndex(p=>p.X == n && p.Y==m)>=0)
                        newPanel.BackColor = clr1;
                    else
                        newPanel.BackColor = clr2;
                   
                }
            }

            this.WindowState = FormWindowState.Maximized;
            Show();
        }
            

    

    }
}
