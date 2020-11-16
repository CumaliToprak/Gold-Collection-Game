﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Altın_Toplama_Oyunu
{

    public abstract class Gamer
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
        public List<Coordinate> gizliAltinListesi;
        public List<Coordinate> acikAltinListesi;
        public Gamer(int altinMiktari, int seferMaaliyeti, int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti)
        {
            this.altinMiktari = altinMiktari;
            this.seferMaaliyeti = seferMaaliyeti;
            this.adimMiktari = adimMiktari;
            this.hedefBelirlemeMaaliyeti = hedefBelirlemeMaaliyeti;

            this.hamleYapmaMaaliyeti = hamleYapmaMaaliyeti;
            this.hedefBelirliMi = false;
            toplananAltinMiktari = 0;
            harcananAltinMiktari = 0;
            acikAltinListesi = StartGame.acikAltinKonumlari;

            gizliAltinListesi = StartGame.gizliAltinKonumlari;
        }

        public abstract void hedefBelirle();

        public void hedefeIlerle()
        {
          
            int gecmisYerX = anlikYer.X;
            int gecmisYerY = anlikYer.Y;

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
            int simdikiYerX = anlikYer.X;
            int simdikiYerY = anlikYer.Y;

            for (int i = 0; i < gizliAltinListesi.Count; i++)
            {
                Coordinate coordinate = gizliAltinListesi[i];
                var coordinateX = coordinate.X;
                var coordinateY = coordinate.Y;
                // eger gizli altin gecmis ve simdiki konumlar arasinda ise gerceklestir.
                if (coordinatAraliktaMi(gecmisYerX, gecmisYerY, simdikiYerX, simdikiYerY, coordinate))
                {
                    gizliAltinListesi.Remove(coordinate);
                    acikAltinListesi.Add(coordinate);
                    StartGame.createBoard.gizliAltiniAcigaCikar(coordinate);
                }

            }
            for (int i = 0; i < acikAltinListesi.Count; i++)
            {
                Coordinate coordinate = acikAltinListesi[i];
                var coordinateX = coordinate.X;
                var coordinateY = coordinate.Y;
                // eger gizli altin gecmis ve simdiki konumlar arasinda ise gerceklestir.
                if (coordinatAraliktaMi(gecmisYerX, gecmisYerY, simdikiYerX, simdikiYerY, coordinate))
                {
                    altinMiktari += coordinate.AltınDegeri;
                    toplananAltinMiktari = +coordinate.AltınDegeri;
                    hedeflenenYer.AltınDegeri = 0;
                    hedefBelirliMi = false;
                    acikAltinListesi.Remove(coordinate); // hedeflenen deger altin listesinden cikarildi

                    Console.WriteLine("uzerinden gecilen altin alindi.");
                }
            }
            StartGame.createBoard.tahtadaVerilenKonumaGit(gecmisYerX, gecmisYerY, simdikiYerX, simdikiYerY);

            if (hedeflenenYerdeAltinVarMi())
            {
                if (hedefeVardiMi())
                {
                    hedeftekiAltiniAl();
                }
                //if(atilabilirAdimMiktari > 0 && acikAltinListesi.Count > 0) // eger atabilecegi adim sayi kalmissa hedef belirler ve hedefe ilerler.
                //{
                //     hedefBelirle();
                //   hedefeIlerle();
                // }
            }
            else
            {
                hedefBelirliMi = false;
                hedefBelirle();
                hedefeIlerle();
            }




        }
        public bool hamleYap()
        { // bir hamlede adimMiktari kadar hareket edilir. 
            atilabilirAdimMiktari = adimMiktari;
            var bulundugumKonum = anlikYer;
            Console.WriteLine(oyuncuAdi+": Hamle basladi : " + bulundugumKonum.X + "," + bulundugumKonum.Y);
            
            if (hedefBelirliMi == true && !hedefeVardiMi() && altinMiktari>=hamleYapmaMaaliyeti)
            {
                hedefeIlerle();
                var vardigimYer = anlikYer;
                Console.WriteLine(vardigimYer.X + "," + vardigimYer.Y + "\n\n");
                return true;
            }

            else if(hedefBelirliMi == false  && altinMiktari >= hedefBelirlemeMaaliyeti)
            {

                hedefBelirle();
                hedefeIlerle();
                var vardigimYer = anlikYer;
                Console.WriteLine(vardigimYer.X + "," + vardigimYer.Y + "\n\n");
                return true;
            }

            return false;

        }
        public int uzaklikHesapla(Coordinate anlikKordinat, Coordinate adayHedefKordinat)
        {
            // bulundugu yer ile hesaplanacak kordinat arasindaki mesafeyi dondur
            return Math.Abs((anlikKordinat.X - adayHedefKordinat.X) ) +Math.Abs(anlikKordinat.Y - adayHedefKordinat.Y);
        }
        private bool hedefeVardiMi()
        {  //hedefe vardi ise true aksi halde false doner 
            return anlikYer.X == hedeflenenYer.X && anlikYer.Y == hedeflenenYer.Y;
        }
        private bool hedeflenenYerdeAltinVarMi()
        {
            return acikAltinListesi.Contains(hedeflenenYer);
        }
        private void hedeftekiAltiniAl()
        {
            altinMiktari += hedeflenenYer.AltınDegeri;
            toplananAltinMiktari = +hedeflenenYer.AltınDegeri;
            hedeflenenYer.AltınDegeri = 0;
            hedefBelirliMi = false;
            acikAltinListesi.Remove(hedeflenenYer); // hedeflenen deger altin listesinden cikarildi

            Console.WriteLine("Hedefteki alindi");
            Console.WriteLine("altin miktari : " + altinMiktari);
            Console.WriteLine("toplananAltinMiktari: " + toplananAltinMiktari);
        }

        public void enKarliAltiniHedefle()
        {
            double hesaplananUzaklik;
            double maliyet;
            double karTutari = int.MinValue;
            Coordinate enKarliKordinat = null;
            foreach (Coordinate kordinat in acikAltinListesi)
            {
                // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                maliyet = (hesaplananUzaklik / adimMiktari) * hamleYapmaMaaliyeti;
                if ((kordinat.AltınDegeri - Convert.ToInt32(maliyet)) > karTutari)
                {
                    karTutari = (kordinat.AltınDegeri - maliyet);
                    enKarliKordinat = kordinat;
                }

            }
            altinMiktari -= hedefBelirlemeMaaliyeti; // hedef belirleme maaliyeti sahip oldugumuz altindan dusuluyor. 
            harcananAltinMiktari += hedefBelirlemeMaaliyeti;
            hedeflenenYer = enKarliKordinat; // hedeflenen yer en yakin kordinat oluyor.
            hedefBelirliMi = true;
        }
        private bool coordinatAraliktaMi(int gecmisYerX, int gecmisYerY, int simdikiYerX, int simdikiYerY, Coordinate sorgulanan)
        {

            var coordinateX = sorgulanan.X;
            var coordinateY = sorgulanan.Y;
            if ((((gecmisYerX < coordinateX && coordinateX < simdikiYerX) ||
                (gecmisYerX > coordinateX && coordinateX > simdikiYerX)) && gecmisYerY == coordinateY && simdikiYerY == coordinateY) ||
                (((gecmisYerY < coordinateY && coordinateY < simdikiYerY) ||
                (gecmisYerY > coordinateY && coordinateY > simdikiYerY)) && gecmisYerX == coordinateX && simdikiYerX == coordinateX))
            {
                return true;
            }
            return false;
        }
    }
}