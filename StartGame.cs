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
        CreateGameBoardFrm createBoard;

        int _boardX, _boardY;
        double _altinOrani, _gizliAltinOrani = 10;
        public StartGame(int boardX, int boardY, double altinOrani, double gizliAltinOrani)
        {
            _boardX = boardX;
            _boardY = boardY;
            _altinOrani = altinOrani;
            _gizliAltinOrani = gizliAltinOrani;
        }

        internal void createGameBoard()
        {
            List<Coordinate> altinKonumlari = altınKareleriBul(_boardX, _boardY, _altinOrani);

            createBoard = new CreateGameBoardFrm(_boardX, _boardY, _altinOrani, altinKonumlari);

            createBoard.create();

        }

        //verilen x,v değerlerine göre altın konumlarını belirleyen metod
        public List<Coordinate> altınKareleriBul(int boardX, int boardY, double altinOrani)
        {
            int kareSayisi = boardX * boardY;
            int altınSayisi = Convert.ToInt32((kareSayisi * altinOrani) / 100);
            
            //altınlarımızın konum bilgilerini tutacak liste.
            List<Coordinate> goldenList = new List<Coordinate>();

            int x,y;
            int temp = 0;
            Random rnd = new Random();

            while (temp < altınSayisi)
            {
                x = rnd.Next(0, boardX);
                y = rnd.Next(0, boardY);
                //eğer random sayılar oyuncuların konumuna gelecekse bir sonraki çevrime gir
                if ((x == 0 && y == 0) || (x == 0 && y == boardY - 1) || (x == boardX - 1 && y == 0) || (x == boardX - 1 && y == boardY - 1)) continue;
                if (goldenList.FindIndex(p=> p.X==x && p.Y==y) < 0)
                {
                    goldenList.Add(new Coordinate { X = x, Y = y });
                    temp++;
                }
                   
            }
            //Altınların konumunu içeren listeyi döndürmeden önce gizli altınları belirleyecek metodu çalıştırır.
            return gizliAltinlariBelirle(goldenList, _gizliAltinOrani );
        }

        public List<Coordinate> gizliAltinlariBelirle(List<Coordinate> altınKonumları, double oran)
        {
            int gizliAltinSayisi = Convert.ToInt32(altınKonumları.Count * oran / 100);
            Console.WriteLine($"altın sayısı {gizliAltinSayisi}");

            int temp = 0;
            Random rnd = new Random();

            while (temp < gizliAltinSayisi)
            {
                int index = rnd.Next(0, altınKonumları.Count);
                if (altınKonumları[index].gizliMi == false )
                {
                    altınKonumları[index].gizliMi = true;
                    temp++;
                }

            }

            return altınKonumları;
        }


        
    

       




    }
}

