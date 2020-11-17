using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class StartGame
    {
        public static PlayGameFrm createBoard { get; set; }

        static public List<Coordinate> gizliAltinKonumlari { set; get; }
        static public List<Coordinate> acikAltinKonumlari { set; get; }
        public static List<Gamer> oyuncularListesi;

        public static int _boardX, _boardY;
        double _altinOrani, _gizliAltinOrani;
        int _altinSayisi;
        public static GamerA gamerA;
        public static GamerB gamerB;
        public static GamerC gamerC;
        public static GamerD gamerD;
        private List<Gamer> sabitOyuncuListesi;

        public StartGame(int boardX, int boardY, double altinOrani, double gizliAltinOrani)
        {
            _boardX = boardX;
            _boardY = boardY;
            _altinOrani = altinOrani;
            _gizliAltinOrani = gizliAltinOrani;
            oyuncularListesi = new List<Gamer>();
           
        }

        internal void createGameBoard()
        {
            int kareSayisi = _boardX * _boardY;
            _altinSayisi = Convert.ToInt32((kareSayisi * _altinOrani) / 100);
            int gizliAltinSayisi = Convert.ToInt32((_altinSayisi * _gizliAltinOrani) / 100);
            int acikAltinSayisi = _altinSayisi - gizliAltinSayisi;

            gizliAltinKonumlari = altinKonumlariniBelirle(gizliAltinSayisi, false);
            acikAltinKonumlari = altinKonumlariniBelirle(acikAltinSayisi, true);
            gamerA = new GamerA(40, 5, 3, 5, 5);
            gamerB = new GamerB(200, 5, 3, 5, 5);
            gamerC = new GamerC(200, 5, 3, 5, 5, 2);
            gamerD = new GamerD(200, 5, 3, 5, 5);

            oyuncularListesi.Add(gamerA);
            oyuncularListesi.Add(gamerB);
            oyuncularListesi.Add(gamerC);
            oyuncularListesi.Add(gamerD);

            sabitOyuncuListesi = new List<Gamer>();
            sabitOyuncuListesi.Add(gamerA);
            sabitOyuncuListesi.Add(gamerB);
            sabitOyuncuListesi.Add(gamerC);
            sabitOyuncuListesi.Add(gamerD);



            createBoard = new PlayGameFrm(_boardX, _boardY, acikAltinKonumlari, gizliAltinKonumlari);

            createBoard.create();
            startCompetetion();

        }

        //verilen x,v değerlerine göre altın konumlarını belirleyen metod
        public List<Coordinate> altinKonumlariniBelirle(int altinSayisi, bool flag)
        {

            //altınlarımızın konum bilgilerini tutacak liste.
            var altinKonumlari = new List<Coordinate>();

            int x, y;
            int temp = 0;
            Random rnd = new Random();

            while (temp < altinSayisi)
            {
                x = rnd.Next(0, _boardX);
                y = rnd.Next(0, _boardY);
                //eğer random sayılar oyuncuların konumuna gelecekse bir sonraki çevrime gir
                if ((x == 0 && y == 0) || (x == 0 && y == _boardY - 1) || (x == _boardX - 1 && y == 0) || (x == _boardX - 1 && y == _boardY - 1)) continue;
                //Atanan altın daha önce daha önce eklenmişse
                if (altinKonumlari.FindIndex(p => p.X == x && p.Y == y) < 0)
                {
                    //acik altin konumlari bulunuyor ise ilk başta bu konumlar gizli altin listesinde var mi diye kontrol et.
                    if (flag && gizliAltinKonumlari.FindIndex(p => p.X == x && p.Y == y) > 0) continue;

                    altinKonumlari.Add(new Coordinate { X = x, Y = y });
                    temp++;
                }

            }

            return altinKonumlari;
        }
        public void startCompetetion()
        {
            
            while (acikAltinKonumlari.Count > 0 && oyuncularListesi.Count > 0)
            {

                for (int i = 0; i < oyuncularListesi.Count; i++)
                {
                    Gamer gamer = oyuncularListesi[i];
                    bool sonuc = gamer.hamleYap();
                    //Console.WriteLine("altinKonumari:" + acikAltinKonumlari.Count);
                    if (sonuc == false)
                    {
                        oyuncularListesi.Remove(gamer);
                        Console.WriteLine("Oyuncu " + gamer.oyuncuAdi + " elendi");
                    }

                    Thread.Sleep(100);
                }
            }
            EndOfGameFrm endOfGameFrm = new EndOfGameFrm();
            endOfGameFrm.SkorDegerleriniAta(sabitOyuncuListesi);
            endOfGameFrm.Show();
        }




    }
}

