using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class StartGame
    {
        frmCreateBoard createBoard;
        public StartGame()
        {

        }

        internal void createGameBoard(int boardX, int boardY, int altinOrani)
        {
            List<Kordinat> altinKonumlari = randomKareleriBul(boardX, boardY, altinOrani);

            createBoard = new frmCreateBoard(boardX, boardY, altinOrani, altinKonumlari);
            createBoard.create();

        }

        public List<Kordinat> randomKareleriBul(int boardX, int boardY, int altinOrani)
        {
            int kareSayisi = boardX * boardY;
            int altınSayisi = (kareSayisi * altinOrani) / 100;

            Random rnd = new Random();

            List<Kordinat> randomList = new List<Kordinat>();

            int x,y;
            int temp = 0;
            Console.WriteLine("Before: {0}",altınSayisi);
            while (temp < altınSayisi)
            {
                x = rnd.Next(0, boardX);
                y = rnd.Next(0, boardY);
                if (randomList.FindIndex(p=> p.X==x && p.Y==y) < 0)
                {
                    randomList.Add(new Kordinat { X = x, Y = y });
                    temp++;
                }
                   
            }

            Console.WriteLine(randomList.Count + ":" );
            foreach (var kordinat in randomList)
            {
                Console.WriteLine(kordinat.X + " , " + kordinat.Y + "    ");
            }
                
            return randomList;
        }


        
    

       




    }
}

