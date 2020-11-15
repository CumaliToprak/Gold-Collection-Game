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
        public string oyuncuAdi;
        public int toplananAltinMiktari;
        public int harcananAltinMiktari; 
        public bool hedefBelirliMi { set; get; }
        private int atilabilirAdimMiktari;
        public int hamleYapmaMaaliyeti { set; get; }// hedefe ilerlerken harcanacak altin miktari 
        public List<Coordinate> altinListesi;

        public Gamer(int altinMiktari, int seferMaaliyeti, int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti, List<Coordinate> altinListesi)
        {
            this.altinMiktari = altinMiktari;
            this.seferMaaliyeti = seferMaaliyeti;
            this.adimMiktari = adimMiktari;
            this.hedefBelirlemeMaaliyeti = hedefBelirlemeMaaliyeti;
            this.altinListesi = altinListesi;
            this.hamleYapmaMaaliyeti = hamleYapmaMaaliyeti;
            this.hedefBelirliMi = false;
            toplananAltinMiktari = 0;
            harcananAltinMiktari = 0; 
        }

        public abstract void hedefBelirle();

        public void hedefeIlerle()
        {
           
            int calculatedValueX = Math.Abs(hedeflenenYer.X - anlikYer.X);
            int calculatedValueY = Math.Abs(hedeflenenYer.Y - anlikYer.Y);
            int shiftingAmountForX = calculatedValueX > atilabilirAdimMiktari ? atilabilirAdimMiktari : calculatedValueX;
            atilabilirAdimMiktari -= shiftingAmountForX;
            int shiftingAmountForY = calculatedValueY > atilabilirAdimMiktari ? atilabilirAdimMiktari : calculatedValueY;
            anlikYer.Y += hedeflenenYer.Y > anlikYer.Y ? shiftingAmountForY : -shiftingAmountForY;
            anlikYer.X += hedeflenenYer.X > anlikYer.X ? shiftingAmountForX : -shiftingAmountForX;
            atilabilirAdimMiktari -= shiftingAmountForY;
            altinMiktari -= hamleYapmaMaaliyeti;
            harcananAltinMiktari += hamleYapmaMaaliyeti;
            Console.WriteLine("Hedefe ilerlendi : " + anlikYer.X + "," + anlikYer.Y + " - " + hedeflenenYer.X + "," + hedeflenenYer.Y);
            

            if (hedefeVardiMi())
            {
                if (hedeflenenYerdeAltinVarMi())
                {
                    hedeftekiAltiniAl();
                }
               if(atilabilirAdimMiktari > 0 && altinListesi.Count > 0) // eger atabilecegi adim sayi kalmissa hedef belirler ve hedefe ilerler.
                {
                    hedefBelirle();
                    hedefeIlerle();
                }
            }
           


        }
        public void hamleYap()
        { // bir hamlede adimMiktari kadar hareket edilir. 
            atilabilirAdimMiktari = adimMiktari;
            Console.WriteLine("Hamle basladi");
            if (hedefBelirliMi == true && !hedefeVardiMi())
            {
                hedefeIlerle();
            }
           
            else
            {

                hedefBelirle();
                hedefeIlerle();
            }
        }
        public int uzaklikHesapla(Coordinate anlikKordinat, Coordinate adayHedefKordinat)
        {
            // bulundugu yer ile hesaplanacak kordinat arasindaki mesafeyi dondur
            return Math.Abs((anlikKordinat.X + anlikKordinat.Y) - (adayHedefKordinat.X + adayHedefKordinat.Y));
        }
        private bool hedefeVardiMi()
        {  //hedefe vardi ise true aksi halde false doner 
            return anlikYer.X == hedeflenenYer.X && anlikYer.Y == hedeflenenYer.Y;
        }
        private bool hedeflenenYerdeAltinVarMi()
        {
            return altinListesi.Contains(hedeflenenYer);
        }
        private void hedeftekiAltiniAl()
        {
            altinMiktari += hedeflenenYer.AltınDegeri;
            toplananAltinMiktari = +hedeflenenYer.AltınDegeri; 
            hedeflenenYer.AltınDegeri = 0;
            hedefBelirliMi = false;
            altinListesi.Remove(hedeflenenYer); // hedeflenen deger altin listesinden cikarildi
            
            Console.WriteLine("Hedefteki alindi");
        }
    }
}