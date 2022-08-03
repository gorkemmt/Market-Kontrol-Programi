using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projedeneme3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //programım başlatılma sürecinde kullandığım bazı comboboxların itemlerini  ve tedarikçi sınıfının nesneleri de hazır ekli olması için burada ekletiyoum
        private void Form1_Load(object sender, EventArgs e)
        {

            calisangorevcmb.Items.Add("Kasiyer");
            calisangorevcmb.Items.Add("Yard. Müdür");
            calisangorevcmb.Items.Add("Müdür");

            calisanizincmb.Items.Add("pazartesi");
            calisanizincmb.Items.Add("salı ");
            calisanizincmb.Items.Add("çarşamba");
            calisanizincmb.Items.Add("perşembe");
            calisanizincmb.Items.Add("cuma");
            calisanizincmb.Items.Add("cumartesi");
            calisanizincmb.Items.Add("pazar");

            uruneklead.Items.Add("Temizlik ürünü");
            uruneklead.Items.Add("Gıda ürünü");
            uruneklead.Items.Add("Kampanya ürünü");


            s.TedarikciEkle("tedarikci-1", "temizlik ürünü", 10000, 25, "istanbul", "pendik", "kavakpınar", "ışıl");
            s.TedarikciEkle("tedarikci-2", "Gıda ürünü", 10000, 18, "istanbul", "maltepe", "cevizli", "gökçe");
            s.TedarikciEkle("tedarikci-3", "Kampanya ürünü", 10000, 89, "istanbul", "bayrampaşa", "vatan", "akın");

        }

        private void girismudur_Click(object sender, EventArgs e)
        {

            kullanıcıdurum.Text = "YÖNETİCİ OTURUMU AÇIK";
            indirimuruncmb.Items.Clear();
            indirimuruncmb.Items.Add("Temizlik ürünü");
            indirimuruncmb.Items.Add("Gıda ürünü");
            indirimuruncmb.Items.Add("Kampanya ürünü");

        }

        private void girismüdür_Click(object sender, EventArgs e)
        {

            kullanıcıdurum.Text = "MÜDÜR OTURUMU AÇIK";
            indirimuruncmb.Items.Clear();
            indirimuruncmb.Items.Add("Kampanya ürünü");

        }

        Sirket s = new Sirket();// tek bir sirket nesnesi kullanıyoruz ve onun referansını ve bellekte yer ayrılmasını sağladık

        private void marketeklebtn_Click(object sender, EventArgs e)//fonk ile marketi ekleme
        {

            if (marketiltbox.Text != "" && marketilcetbox.Text != "" && marketmahtbox.Text != "" && marketsokaktbox.Text != "")//market oluşurturulurken adres kısmının boş geçimemesi için if ile kontrol ettirdim
            {
                // burada form üzerindeki texboxlardan  değerleri alarak MarketEkle fonkisyonuna parametre olarak gönderiyoruz

                s.MarketEkle(subeadtbox.Text, marketiltbox.Text, marketilcetbox.Text, marketmahtbox.Text, marketsokaktbox.Text);
                calisansubecmb.Items.Add(subeadtbox.Text);       //oluşturduğumuz marketlerin sube adlarını daha sonra calışan ve ürün eklerken kullanacağımız ocmboboxlara item olarak ekletiyorum.
                uruneklesube.Items.Add(subeadtbox.Text);
                subedegiscmb.Items.Add(subeadtbox.Text);
                indirimsube.Items.Add(subeadtbox.Text);
            }
            else
            {
                MessageBox.Show("! Market Oluşturuken Adres Bölümünde Boş Değer Olamaz");
            }

        }

        private void marketlistelebuton_Click(object sender, EventArgs e)//marketli listboxa yazma
        {
            //burada MarketListele fonksiyonunuda kullanarak listbox a marketler listesini çekiyoruz ve yazdırıyoruz
            listBox1.Items.Clear();
            listBox1.Items.Add("MARKETLER:");
            foreach (Market market in s.MarketListele())
            {
                listBox1.Items.Add(" ŞUBE ADI: " + market.Adi + "  ADRES : " + market.adres.Il + " / " + market.adres.Ilce + " " + market.adres.Mahalle + " mahallesi " + market.adres.Sokak + " sokak ");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Market market in s.MarketListele())
            {
                if (market.Adi == calisansubecmb.Text)
                {
                    if (calisanil.Text != "" && calisanilce.Text != "" && calisanmah.Text != "" && calisansokak.Text != "")
                    {
                        market.CalisanEkle(calisanadtbox.Text, calisansubecmb.Text, calisangorevcmb.Text, calisanizincmb.Text, Convert.ToInt32(calisanmaas.Text), calisanil.Text, calisanilce.Text, calisanmah.Text, calisansokak.Text);
                        calisansec.Items.Add(calisanadtbox.Text);
                    }
                    else
                    {
                        MessageBox.Show("! Çalışan Eklenirken Adres Bölümünde Boş Değer Olamaz");
                    }
                }
            }
        }

        private void calısanlistelebuton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("ÇALIŞANLAR:");
            foreach (Market market in s.marketler)
            {
                foreach (Calisan calısan in market.calisanlar)
                {
                    if (calısan.adres.Il != "" && calısan.adres.Ilce != "" && calısan.adres.Mahalle != "" && calısan.adres.Sokak != "")
                    {
                        listBox1.Items.Add("  ADI: " + calısan.CalisanAdi + "  ŞUBESİ: " + calısan.Sube + "  GÖREVİ: " + calısan.Gorev + "  İZİN GÜNÜ: " + calısan.HaftalikIzingunu + "  MAAŞI: " + calısan.Maas + "  KALAN YILLIK İZİN: " + calısan.KalanYillikIzin + " gün" + "  ÇALIŞMA SÜRESİ: " + calısan.Calismagunu + " gün çalıştı" + "  ADRES: " + calısan.adres.Il + " / " + calısan.adres.Ilce + " " + calısan.adres.Mahalle + " mahallesi " + calısan.adres.Sokak + " sokak ");
                    }
                    else
                    {
                        market.calisanlar.Remove(calısan);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Market market in s.MarketListele())
            {
                if (market.Adi == uruneklesube.Text)
                {
                    market.UrunEkle(uruneklead.Text, uruneklesube.Text, Convert.ToInt32(uruneklesayı.Text), Convert.ToInt32(uruneklefiyat.Text));

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("ÜRÜNLER:");
            foreach (Market market in s.marketler)
            {
                foreach (Urun urun in market.urunler)
                {
                    if (urun.UrunIndirimTarihi == default(DateTime))
                    {
                        listBox1.Items.Add("  TÜRÜ: " + urun.UrunAdi + "  ŞUBE: " + urun.Sube + "  STOK DURUMU: " + urun.UrunSayisi + " adet stok var " + " FİYAT: " + urun.UrunFiyati + "tl" + "  ÜRÜNE İNDİRİM YAPILMAMIŞTIR");
                    }
                    else
                    {
                        listBox1.Items.Add("  TÜRÜ: " + urun.UrunAdi + "  ŞUBE: " + urun.Sube + "  STOK DURUMU: " + urun.UrunSayisi + " adet stok var " + " FİYAT: " + urun.UrunFiyati + "tl" + "  SON İNDİRİM TARİHİ: " + urun.UrunIndirimTarihi);
                    }
                }
            }
        }

        private void zambtn_Click(object sender, EventArgs e)////seçili nesneyi string olarak buluyor
        {
            foreach (Market market in s.marketler)
            {
                foreach (Calisan calisan in market.calisanlar)
                {
                    if (calisan.CalisanAdi == calisansec.Text)
                    {
                        if (calisan.Maas < Convert.ToInt32(zamtbox.Text))
                        {
                            market.MaasDegistir(calisan, Convert.ToInt32(zamtbox.Text));
                            MessageBox.Show(" Calışan Maaşı Yükseltildi");
                        }
                        else
                        {
                            MessageBox.Show("! Çalışanın yeni maaşı daha yüksek olmalıdır");
                        }
                    }
                }
            }
        }

        private void subedegisbtn_Click(object sender, EventArgs e)
        {
            foreach (Market market in s.marketler)
            {
                foreach (Calisan calisan in market.calisanlar)
                {
                    if (calisan.CalisanAdi == calisansec.Text)
                    {
                        market.SubeDegistir(calisan, subedegiscmb.Text);
                        MessageBox.Show("sube değiştirildi");
                    }
                }
            }
        }

        private void terfibtn_Click(object sender, EventArgs e)
        {
            string yenigörev = "";

            if (mudurradio.Checked)
            {
                yenigörev = "Müdür";
            }
            else if (yardmradio.Checked)
            {
                yenigörev = "Yard.Müdür";
            }

            foreach (Market market in s.marketler)
            {
                foreach (Calisan calisan in market.calisanlar)
                {
                    if (calisan.CalisanAdi == calisansec.Text)
                    {
                        market.GörevDegistir(calisan, yenigörev);
                        MessageBox.Show("Çalışan Görevi Değiştirildi");
                    }
                }
            }
        }

        private void indirimbtn_Click(object sender, EventArgs e)
        {
            foreach (Market market in s.marketler)
            {
                foreach (Urun urun in market.urunler)
                {
                    if (urun.UrunAdi == indirimuruncmb.Text && urun.Sube == indirimsube.Text)
                    {
                        market.FiyatDegistir(urun, Convert.ToInt32(indirimfiyattbox.Text));
                        MessageBox.Show("İndirim Yapıldı");
                    }
                }
            }
        }

        private void tedarikcilistele_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("TEDARİKÇİLERİMİZ:");
            foreach (Tedarikci ted in s.TedarikciLstele())
            {
                listBox1.Items.Add(" ADI: " + ted.Adi + " ÜRÜNÜ: " + ted.urun.UrunAdi + " TEDARİKÇİ STOĞU: " + ted.urun.UrunSayisi + "adet" + " SATIŞ FİYATLARI: " + ted.urun.UrunFiyati + "tl" + "  ADRES : " + ted.adres.Il + " / " + ted.adres.Ilce + " " + ted.adres.Mahalle + " mahallesi " + " " + ted.adres.Sokak + " sokak ");
            }
        }

    }
}
