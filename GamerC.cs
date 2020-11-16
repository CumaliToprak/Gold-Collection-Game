using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerC : Gamer
    {
        public GamerC(int altinMiktari, int seferMaaliyeti,
            int adimMiktari, int hedefBelirlemeMaaliyeti, int hamleYapmaMaaliyeti) :
            base(altinMiktari, seferMaaliyeti, adimMiktari, hedefBelirlemeMaaliyeti, hamleYapmaMaaliyeti)
        {
            // C oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.Y = StartGame._boardY-1;
            anlikYer.X = StartGame._boardX - 1;
        }
        public override void hedefBelirle()
        {
            gizliAltiniAcigaCikar(1);

            int enYakinAltinMesafesi = int.MaxValue;
            int hesaplananUzaklik;
            Coordinate enYakinKordinat = null;
            foreach (Coordinate kordinat in acikAltinListesi)
            {
                // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                // her seferde en yakin kordinata ulasiliyor.
                if (enYakinAltinMesafesi > hesaplananUzaklik)
                {
                    enYakinAltinMesafesi = hesaplananUzaklik;
                    enYakinKordinat = kordinat;
                }
            }
            altinMiktari -= hedefBelirlemeMaaliyeti; // hedef belirleme maaliyeti sahip oldugumuz altindan dusuluyor. 
            harcananAltinMiktari += hedefBelirlemeMaaliyeti;
            hedeflenenYer =enYakinKordinat ;
            //hedeflenenYer.X = 0;
            //hedeflenenYer.Y = 0;
            // hedeflenen yer en yakin kordinat oluyor.
            hedefBelirliMi = true;

        }
        
        private void gizliAltiniAcigaCikar(int cikaracagiGizliAltinMik)
        {
            Stack<Coordinate> kordinatStack = new Stack<Coordinate>();
            int enYakinGizliAltinMesafesi = int.MaxValue;
            int hesaplananUzaklik;
            Coordinate enYakinKordinat = null;
            // en yakin gizli altinlar stack in en ustunde
            foreach (Coordinate kordinat in gizliAltinListesi)
            {
                // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                // her seferde en yakin kordinata ulasiliyor.
                if (enYakinGizliAltinMesafesi > hesaplananUzaklik)
                {
                    enYakinGizliAltinMesafesi = hesaplananUzaklik;
                    enYakinKordinat = kordinat;
                    kordinatStack.Push(kordinat);
                }
            }
            while(cikaracagiGizliAltinMik > 0 &&kordinatStack.Count > 0)
            {
                Coordinate acigaCikanAltin = kordinatStack.Pop();
                gizliAltinListesi.Remove(acigaCikanAltin);
                acikAltinListesi.Add(acigaCikanAltin);
                StartGame.createBoard.gizliAltiniAcigaCikar(acigaCikanAltin);
                Console.WriteLine("C oyuncusu gizli altini aciga cikardi" + acigaCikanAltin.ToString());
                cikaracagiGizliAltinMik--; 
            }


        }
        
    }
}
