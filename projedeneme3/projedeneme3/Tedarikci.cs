using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projedeneme3
{
    class Tedarikci: Sirket                                   //tedarikçi sınıfıda şirket sınıfından kalıtım alıyor

         
    {                                           //özellikleri ve kurucu metodunu 
        

        public Urun urun { get; set; }

        public Adres adres { get; set; }


        public Tedarikci()
        {
            adres = new Adres();

            urun = new Urun();
 
        }


    }
}
