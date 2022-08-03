using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projedeneme3
{
    class Calisan
    {


        public string CalisanAdi { get; set; }

        public string Sube { get; set; }        //nesnelerin özelliklerini oluştururken auto-implemented property kullandım ve get, set özelliklerini açık bıraktım

        public string Gorev { get; set; }

        public int Maas { get; set; }

        public string HaftalikIzingunu { get; set; }

        public int KalanYillikIzin { get; set; }

        public Adres adres { get; set; }

        public int Calismagunu { get; set; }

        public List<Calisan> Calisanlar { get; set; }


        public Calisan()                                          /*calışan sınıfının kurucu metodu içerisinde
                                                                     her çalışan eklendiğinde yeni başladığı için çalışma gününü 0 olarak ve 
                                                                    başlangıçta her çalışanın 14 gün yıllık izni olmasını burada  default olarak atıyoruz*/
        {

            this.KalanYillikIzin = 14;
            this.Calismagunu = 0;

            adres = new Adres();

        }


    }
}
