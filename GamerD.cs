using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerD : Gamer
    {
        List<Gamer> oyuncular;
        public GamerD(int altinMiktari, 
            int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti) :
            base(altinMiktari,  adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // C oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.Y = StartGame._boardY - 1;
            anlikYer.X = 0;
            oyuncuAdi = "D";
            oyuncular = StartGame.oyuncularListesi;
        }
        public override void hedefBelirle()
        {
            double hesaplananUzaklik;
            double maliyet;
            double karTutari = int.MinValue;
            Coordinate enKarliKordinat = null;
            bool dahaOnceUlasirMi = false;
            List<Coordinate> hedefler = new List<Coordinate>();
            Stack<Coordinate> enKarliKordinatStack = new Stack<Coordinate>();

            //diğer oyuncuların hedeflerine onlardan önce ulaşabiliryor mu diye kontrol edecek



            if (oyuncular.Count == 1)
            {
                enKarliAltiniHedefle();

            }
            else
            {
                Console.WriteLine("calsiti");


                foreach (Coordinate kordinat in acikAltinListesi)
                {
                    // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                    hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                    maliyet = (hesaplananUzaklik / adimMiktari) * hamleYapmaMaaliyeti;
                    if ((kordinat.AltınDegeri - Convert.ToInt32(maliyet)) > karTutari)
                    {
                        karTutari = (kordinat.AltınDegeri - maliyet);

                        enKarliKordinatStack.Push(kordinat); // coordinatlar stack e atiliyor.
                       
                    }

                }


                while (enKarliKordinat == null)
                {
                   
                    

                    for (int i = 0; i < oyuncular.Count; i++)
                    {
                        var oyuncuKordinati = oyuncular[i].hedeflenenYer;
                        if ( oyuncuKordinati != null && enKarliKordinat != null && enKarliKordinat.Equals(oyuncuKordinati) && oyuncular[i].oyuncuAdi != oyuncuAdi  )
                        {
                            Console.WriteLine("D oyuncusunun en karli hedefi " + oyuncular[i].oyuncuAdi + " ile cakisti .Hangisi daha once varacak kontrol edilecek");

                            if (!dOyuncusuOnceVarirMi(enKarliKordinat, oyuncular[i]))
                            {

                                enKarliKordinat = null;
                                if(enKarliKordinatStack.Count == 0)
                                {
                                    StartGame.oyuncularListesi.Remove(StartGame.gamerD); // d oyuncusu elenecek
                                    Console.WriteLine("D oyuncusu kalan altini alamayacagi icin elendi");
                                }
                            }
                        }
                    }
                    enKarliKordinat = enKarliKordinatStack.Pop();


                }

                altinMiktari -= hedefBelirlemeMaaliyeti; // hedef belirleme maaliyeti sahip oldugumuz altindan dusuluyor. 
                harcananAltinMiktari += hedefBelirlemeMaaliyeti;


                hedeflenenYer = enKarliKordinat; // hedeflenen yer en yakin kordinat oluyor.
                hedefBelirliMi = true;

            }
            Console.WriteLine("Hedef Belirlendi : D oyuncusunun hedefi" + hedeflenenYer.X + "," + hedeflenenYer.Y);




        }
        private bool dOyuncusuOnceVarirMi(Coordinate hedeflenenYer, Gamer oyuncu)
        {
            int hedeflenenYereUzaklik = uzaklikHesapla(anlikYer, hedeflenenYer);
            int oyuncununHedeflenenYereUzakligi = uzaklikHesapla(oyuncu.anlikYer, oyuncu.hedeflenenYer);
            int hamleSayisi = hedeflenenYereUzaklik / adimMiktari; // adim miktari bir hamlede atacak adim
            int oyuncuHamleSayisi = oyuncununHedeflenenYereUzakligi / oyuncu.adimMiktari;
            if (hamleSayisi < oyuncuHamleSayisi)
                return true;
            return false;

        }



    }
}
