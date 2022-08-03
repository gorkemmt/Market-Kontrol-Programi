using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projedeneme3
{
    class Market : Sirket        // burada market sınıfının  şirket sınıfının subclass ı olarak tanaımladık bu sayede şirket superclassının Adi özelliğini alt sınıflardada kullanmamıza izin verdi           
    {
                                                        //daha sonra market sınıfının özelliklerini oluşturduk
       

        public Adres adres { get; set; }

        public Urun urun { get; set; }
  
        
        public List<Calisan> calisanlar { get; set; }// calışanların tutulacağı list yapısı

        public List<Urun> urunler { get; set; }


        public Market()                                         //market sınıfının kurucu metodu   
        {
            this.adres = new Adres();

            this.urunler = new List<Urun>();

            this.calisanlar = new List<Calisan>();
        }
                                                                        //CalışanEkle fonksiyonunu burada oluşturdum 

        public void CalisanEkle(string fad, string fsube, string fgorev, string fizingunu, int fmaas, string fil, string filce, string fmahalle, string fsokak)
        {
            Calisan c = new Calisan();

            c.CalisanAdi = fad;
            c.Sube = fsube;
            c.Gorev = fgorev;
            c.HaftalikIzingunu = fizingunu;
            c.Maas = fmaas;
            c.adres.Il = fil;
            c.adres.Ilce = filce;
            c.adres.Mahalle = fmahalle;
            c.adres.Sokak = fsokak;

            calisanlar.Add(c);

        }

        public List<Calisan> CalisanlariListele()
        {
            return calisanlar;
        }

        public void UrunEkle(string uad,string usube,  int ustok,int ufiyat )
        {
            Urun u = new Urun {Sube=usube,UrunAdi=uad,UrunSayisi=ustok,UrunFiyati=ufiyat };       //Burada UruneEkle fonksiyonunu nesne başlatıcısı kullanarak yeni ürün nesnesini oluşturmasını sağladık

                                                  //daha sonrada urunler listesine ekletiyoruz

            urunler.Add(u);                                

        }

        public List<Urun> UrunleriListele()
        {
            return urunler;
        }

                                                                            //yönetici veya müdür kullanıcısının listelerdeki veriler üzerinde değişiklik yapmasınına yarayacak olan fonksiyonları yazdık
        public void MaasDegistir(Calisan a,int yenim)
        {
            a.Maas = yenim;
        }


        public void SubeDegistir(Calisan a, string yenis)
        {
            a.Sube = yenis;
        }

        public void GörevDegistir(Calisan a, string yenig)
        {
            a.Gorev = yenig;
        }

        public void FiyatDegistir(Urun a, int yenif)
        {
            a.UrunFiyati = yenif;
            a.UrunIndirimTarihi = DateTime.Now;                                         
        }

        
    }
}
