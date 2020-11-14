﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    class GamerA : Gamer
    {
        public GamerA(int altinMiktari, int seferMaaliyeti,
            int adimMiktari, int hedefBelirlemeMaaliyeti, List<Coordinate> altinKordinatlari) :
            base(altinMiktari, seferMaaliyeti, adimMiktari, hedefBelirlemeMaaliyeti, altinKordinatlari)
        {
            // A oyuncusunun baslangictaki yeri ataniyor.
            anlikYer = new Coordinate();
            anlikYer.X = 0;
            anlikYer.Y = 0; 
        }
        
        public override void hedefBelirle()
        {
            int enYakinAltinMesafesi = int.MaxValue;
            int hesaplananUzaklik;
            Coordinate enYakinKordinat = null ; 
            foreach (Coordinate kordinat in altinListesi)
            {
                // oyuncunun bulundugu yer ile aday yer arasindaki uzaklik
                hesaplananUzaklik = uzaklikHesapla(anlikYer, kordinat);
                // her seferde en yakin kordinata ulasiliyor.
                if (!kordinat.gizliMi &&enYakinAltinMesafesi > hesaplananUzaklik )
                {
                    enYakinAltinMesafesi = hesaplananUzaklik;
                    enYakinKordinat = kordinat; 
                }
            }
            hedeflenenYer = enYakinKordinat; // hedeflenen yer en yakin kordinat oluyor.
            Console.WriteLine("A oyuncusunun hedefi"+hedeflenenYer.X + "," + hedeflenenYer.Y);

        }
    }
}