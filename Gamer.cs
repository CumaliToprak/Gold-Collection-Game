using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Altın_Toplama_Oyunu
{

    abstract class Gamer
    {
        public int altinMiktari { set; get; }
        public Coordinate hedeflenenYer { set; get; }
        public Coordinate anlikYer { set; get; }
        public int seferMaaliyeti { set; get; }
        public int adimMiktari { set; get; } // describes step amount for one time voyage 
        public int hedefBelirlemeMaaliyeti { set; get; }
        public bool hedefBelirliMi { set; get; }
        public List<Coordinate> altinListesi;

        public Gamer(int altinMiktari, int seferMaaliyeti, int adimMiktari, int hedefBelirlemeMaaliyeti, List<Coordinate> altinListesi)
        {
            this.altinMiktari = altinMiktari;
            this.seferMaaliyeti = seferMaaliyeti;
            this.adimMiktari = adimMiktari;
            this.hedefBelirlemeMaaliyeti = hedefBelirlemeMaaliyeti;
            this.altinListesi = altinListesi;
            this.hedefBelirliMi = false;
        }

        public abstract void hedefBelirle();

        public bool hedefeIlerle()
        {
            if (anlikYer.X == hedeflenenYer.X && anlikYer.Y == hedeflenenYer.Y)
            {
                return true;
            }
            else
            {
                int tempStepLimit = adimMiktari;
                int calculatedValueX = Math.Abs(hedeflenenYer.X - anlikYer.X);
                int calculatedValueY = Math.Abs(hedeflenenYer.Y - anlikYer.Y);
                int shiftingAmountForX = calculatedValueX > tempStepLimit ? tempStepLimit : calculatedValueX;
                tempStepLimit -= shiftingAmountForX;
                int shiftingAmountForY = calculatedValueY > tempStepLimit ? tempStepLimit : calculatedValueY;
                anlikYer.Y += hedeflenenYer.Y > anlikYer.Y ? shiftingAmountForY : -shiftingAmountForY;
                anlikYer.X += hedeflenenYer.X > anlikYer.X ? shiftingAmountForX : -shiftingAmountForX;
                Console.WriteLine(anlikYer.X + "," + anlikYer.Y + " - " + hedeflenenYer.X + "," + hedeflenenYer.Y);
                return false;
            }


        }
        public int uzaklikHesapla(Coordinate anlikKordinat,Coordinate adayHedefKordinat)
        { 
            // bulundugu yer ile hesaplanacak kordinat arasindaki mesafeyi dondur
            return Math.Abs( (anlikKordinat.X+ anlikKordinat.Y)-(adayHedefKordinat.X+adayHedefKordinat.Y) );
        }

    }
}