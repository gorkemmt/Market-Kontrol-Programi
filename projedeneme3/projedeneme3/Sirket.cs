using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projedeneme3
{
    class Sirket                                              
    {

                                                                        
        public string Adi { get; set; }

        public List<Market> marketler { get; set; }
                                                                  //  market ve tedarikçi nesnelerini içinde tutacağımız list yapılarını ve özelliklerin oluşturdum
        public List<Tedarikci> tedarikciler { get; set; }

        public Sirket()
        {

            marketler = new List<Market>();
            tedarikciler = new List<Tedarikci>();

        }      

        public  void MarketEkle(string subead, string il, string ilce, string mahalle, string sokak)
        {
            Market m = new Market();

            m.Adi = subead;
            m.adres.Il = il;                                          //MarketEkle ve TedarikcieEkle fonksiyonlarını oluşturdum bu sayade form içinde nesne yi fonsiyonlar kullanarak oluşturabileceğiz
            m.adres.Ilce = ilce;
            m.adres.Mahalle = mahalle;
            m.adres.Sokak = sokak;

            marketler.Add(m);

        }                                                   

        public void TedarikciEkle(string tedarikciad,string turunad,int urunstogu,int uruntsatisfiyati, string il, string ilce, string mahalle, string sokak)
        {
            Tedarikci t = new Tedarikci();

            t.Adi = tedarikciad;
            t.urun.UrunAdi=turunad;
            t.urun.UrunSayisi= urunstogu;
            t.urun.UrunFiyati= uruntsatisfiyati;
            t.adres.Il = il;
            t.adres.Ilce = ilce;
            t.adres.Mahalle = mahalle;
            t.adres.Sokak = sokak;

            tedarikciler.Add(t);
             
        }

                                                                    //bu kısımda marketler ve tedarikciler listelerini döndürecek olan Listeleme fonksiyonlarını oluşturduk
        public List<Market> MarketListele()
        {
            return marketler;
        }

        public List<Tedarikci> TedarikciLstele()
        {
            return tedarikciler;
        }


    }
}
