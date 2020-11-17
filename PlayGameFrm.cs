using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altın_Toplama_Oyunu
{
    public partial class PlayGameFrm : Form
    {
        readonly int _boardX, _boardY;
        readonly int X, Y;
        Label[,] _boardLabels;
        List<Coordinate> _acikAltinKonumlari;
        List<Coordinate> _gizliAltinKonumlari;
        Color clr1 = Color.Gold;
        Color clr2 = Color.Red;
        Color clr3 = Color.DarkGray;
        GamerA gamerA;
        GamerB gamerB;
        GamerC gamerC;
        GamerD gamerD;
        private void CreateGameBoardFrm_Load(object sender, EventArgs e)
        {

        }

        public PlayGameFrm(int boardX, int boardY, List<Coordinate> acikAltinKonumlari, List<Coordinate> gizliAltinKonumlari)
        {
            _boardX = boardX;
            _boardY = boardY;
            X = (77 - boardX) * 10; //Game board form boyutuna göre ne kadar sağdan konumlanmaya başlamalı
            Y = (40 - boardY) * 10; //Game Board form boyutuna göre ne kadar aşağıdan konumlanmaya başlamalı
            _acikAltinKonumlari = acikAltinKonumlari;
            _gizliAltinKonumlari = gizliAltinKonumlari;
            gamerA = StartGame.gamerA;
            gamerB = StartGame.gamerB;
            gamerC = StartGame.gamerC;
            gamerD = StartGame.gamerD;

        }


        public void create()
        {

            const int boyut = 20;



            _boardLabels = new Label[_boardX, _boardY]; ; //label array

            for (var n = 0; n < _boardX; n++)
            {
                for (var m = 0; m < _boardY; m++)
                {
                    //yeni panel oluşturulur.
                    var newLabel = new Label
                    {
                        Size = new Size(boyut, boyut),
                        Location = new Point(X + boyut * n, Y + boyut * m),
                        AutoSize = true,
                        Text = $"|  |",
                        Font = new Font("Arial", 8, FontStyle.Regular),
                        BackColor = clr3

                    };

                    //Oyuncuları gösteren konumları belirleme ve ui kısmında görüntüleme
                    if (n == 0 && m == 0)
                    {
                        newLabel.Text = "A ";
                        newLabel.Font = new Font("Arial", 8, FontStyle.Bold);
                        newLabel.BackColor = Color.LightGreen;
                    }
                    else if (n == _boardX - 1 && m == 0)
                    {
                        newLabel.Text = "B ";
                        newLabel.Font = new Font("Arial", 8, FontStyle.Bold);
                        newLabel.BackColor = Color.LightBlue;
                    }
                    else if (n == _boardX - 1 && m == _boardY - 1)
                    {
                        newLabel.Text = "C ";
                        newLabel.Font = new Font("Arial", 8, FontStyle.Bold);
                        newLabel.BackColor = Color.LightPink;
                    }
                    else if (n == 0 && m == _boardY - 1)
                    {
                        newLabel.Text = "D ";
                        newLabel.Font = new Font("Arial", 8, FontStyle.Bold);
                        newLabel.BackColor = Color.DarkOrange;
                    }


                    // Oluşturulan paneli görüntülemek için Form control'e eklenir
                    Controls.Add(newLabel);
                    // panel konumları arrayde tutarız. İleriki kullanımlar için.
                    _boardLabels[n, m] = newLabel;



                    int index_acikAltinMi = _acikAltinKonumlari.FindIndex(p => p.X == n && p.Y == m);
                    int index_gizliAltinMi = _gizliAltinKonumlari.FindIndex(p => p.X == n && p.Y == m);
                    //Altınları: sarı, gizli altınlar: kırmızı
                    if (index_acikAltinMi >= 0 || index_gizliAltinMi >= 0)
                    {

                        int altinDegeri = 0;
                        //altın değerlerini atamak için random index uretimi
                        Random rnd = new Random();
                        int tmp;
                        tmp = rnd.Next(1, 5);

                        //altın değerlerini atama işlemi
                        switch (tmp)
                        {
                            case 1:
                                altinDegeri = 5;
                                break;
                            case 2:
                                altinDegeri = 10;
                                break;
                            case 3:
                                altinDegeri = 15;
                                break;
                            case 4:
                                altinDegeri = 20;
                                break;
                        }

                        // altın konumlarını ve diğer blokları renklendirme
                        if (index_gizliAltinMi >= 0)
                        {
                            var altin = _gizliAltinKonumlari[index_gizliAltinMi];
                            altin.AltınDegeri = altinDegeri;
                            newLabel.BackColor = clr2;
                            _boardLabels[altin.X, altin.Y].Text = "? ";
                        }
                        else
                        {
                            var altin = _acikAltinKonumlari[index_acikAltinMi];
                            altin.AltınDegeri = altinDegeri;
                            newLabel.BackColor = clr1;
                            _boardLabels[altin.X, altin.Y].Text = altinDegeri.ToString();
                        }
                    }

                }
            }


            this.WindowState = FormWindowState.Maximized;
            Show();

        }

        private void PlayGameFrm_Load(object sender, EventArgs e)
        {

        }

        public void oyuncularinKonumunuYenile()
        {
            
            _boardLabels[gamerA.anlikYer.X, gamerA.anlikYer.Y].Text = "A ";
            _boardLabels[gamerA.anlikYer.X, gamerA.anlikYer.Y].BackColor = Color.LightGreen; 
            _boardLabels[gamerA.anlikYer.X, gamerA.anlikYer.Y].Font = new Font("Arial", 8, FontStyle.Bold);
            _boardLabels[gamerB.anlikYer.X, gamerB.anlikYer.Y].Text = "B ";
            _boardLabels[gamerB.anlikYer.X, gamerB.anlikYer.Y].BackColor= Color.LightBlue; 
            _boardLabels[gamerB.anlikYer.X, gamerB.anlikYer.Y].Font = new Font("Arial", 8, FontStyle.Bold);
            _boardLabels[gamerC.anlikYer.X, gamerC.anlikYer.Y].Text = "C ";
            _boardLabels[gamerC.anlikYer.X, gamerC.anlikYer.Y].BackColor = Color.LightPink; 
            _boardLabels[gamerC.anlikYer.X, gamerC.anlikYer.Y].Font = new Font("Arial", 8, FontStyle.Bold);
            _boardLabels[gamerD.anlikYer.X, gamerD.anlikYer.Y].Text = "D ";
            _boardLabels[gamerD.anlikYer.X, gamerD.anlikYer.Y].BackColor=Color.DarkOrange;
            _boardLabels[gamerD.anlikYer.X, gamerD.anlikYer.Y].Font = new Font("Arial", 8, FontStyle.Bold);


            Show();
            this.Refresh();// ekran yenileniyor...


        }
        public void gecmisKonumuTemizle(int x, int y )
        {
            Label label = _boardLabels[x, y];
            label.Text = $"| |";
            label.BackColor = clr3; // arka plan darkGray Oluyor.
            Show();
            this.Refresh();// ekran yenileniyor...
        }
        public void gizliAltiniAcigaCikar(Coordinate kordinat)
        {
            int X = kordinat.X;
            int Y = kordinat.Y;
            Label label = _boardLabels[X, Y];
            label.Text = kordinat.AltınDegeri.ToString();
            label.BackColor = clr1;

            Controls.Add(label);


            Show();
            this.Refresh();// ekran yenileniyor...


        }





    }
}
