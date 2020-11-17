using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerD : Gamer
    {
        public GamerD(int altinMiktari, int seferMaaliyeti,
            int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti) :
            base(altinMiktari, seferMaaliyeti, adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // C oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.Y = StartGame._boardY - 1;
            anlikYer.X = 0;
            oyuncuAdi = "D";
        }
        public override void hedefBelirle()
        {
            double hesaplananUzaklik;
            double maliyet;
            double karTutari = int.MinValue;
            Coordinate enKarliKordinat = null;
            //diğer oyuncuların hedeflerine onlardan önce ulaşabiliryor mu diye kontrol edecek
            List<Gamer> oyuncular = StartGame.oyuncularListesi;
            bool dahaOnceUlasirMi = false;
            List<Coordinate> hedefler = new List<Coordinate>();

            foreach (var oyuncu in oyuncular)
            {
                if (oyuncu.hedefBelirliMi)
                {
                    hesaplananUzaklik = uzaklikHesapla(oyuncu.anlikYer, oyuncu.hedeflenenYer);

                    if (uzaklikHesapla(anlikYer, oyuncu.hedeflenenYer) < hesaplananUzaklik)
                    {
                        enYakinKordinat = oyuncu.hedeflenenYer;
                        dahaOnceUlasirMi = true;
                    }
                }
                hedefler.Add(oyuncu.hedeflenenYer);
            }


            if (!dahaOnceUlasirMi)
            {
                foreach (Coordinate kordinat in acikAltinListesi)
                {
                    //oyuncuların hedeflerine onlardan önce ulaşamıyorsa bu hedefleri hariç tutar.
                    if (!hedefler.Contains(kordinat))
                    {

                        // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                        hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                        maliyet = (hesaplananUzaklik / adimMiktari) * hamleYapmaMaaliyeti;
                        if ((kordinat.AltınDegeri - Convert.ToInt32(maliyet)) > karTutari)
                        {
                            karTutari = (kordinat.AltınDegeri - maliyet);
                            enKarliKordinat = kordinat;
                        }


                        // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                        hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                        // her seferde en yakin kordinata ulasiliyor.

                    }

                }
            }

            altinMiktari -= hedefBelirlemeMaaliyeti; // hedef belirleme maaliyeti sahip oldugumuz altindan dusuluyor. 
            harcananAltinMiktari += hedefBelirlemeMaaliyeti;


            hedeflenenYer = enKarliKordinat; // hedeflenen yer en yakin kordinat oluyor.
            hedefBelirliMi = true;



        }



    }
}
