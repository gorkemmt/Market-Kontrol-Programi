using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projedeneme3
{
    class Urun                                                      //ürün sınıfının özellikleri ve constructor
    {
        public string Sube { get; set; }

        public string UrunAdi { get; set; }

        public int UrunSayisi { get; set; }

        public int UrunFiyati { get; set; }

        public DateTime UrunIndirimTarihi { get; set; }


        public Urun()
        {
            this.UrunIndirimTarihi = default(DateTime);
        }


        
    }
}
