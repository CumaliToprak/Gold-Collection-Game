using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerB : Gamer
    {
        public GamerB(int altinMiktari, int seferMaaliyeti, int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti)
            : base(altinMiktari, seferMaaliyeti, adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // B oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.X = 0;
            anlikYer.Y = 0;
        }

        public override void hedefBelirle()
        {
            double hesaplananUzaklik;
            double maliyet;
            double karTutari = 0;
            Coordinate enKarliKordinat = null;
            foreach (Coordinate kordinat in acikAltinListesi)
            {
                // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                maliyet = (hesaplananUzaklik / 3) * hamleYapmaMaaliyeti;
                if ((kordinat.AltınDegeri - Convert.ToInt32( maliyet ) ) > karTutari)
                {
                    karTutari = (kordinat.AltınDegeri - maliyet);
                    enKarliKordinat = kordinat;
                }

            }
            altinMiktari -= hedefBelirlemeMaaliyeti; // hedef belirleme maaliyeti sahip oldugumuz altindan dusuluyor. 
            harcananAltinMiktari += hedefBelirlemeMaaliyeti;
            hedeflenenYer = enKarliKordinat; // hedeflenen yer en yakin kordinat oluyor.
            hedefBelirliMi = true;
            Console.WriteLine("Hedef Belirlendi : B oyuncusunun hedefi" + hedeflenenYer.X + "," + hedeflenenYer.Y);

        }
    }
}
