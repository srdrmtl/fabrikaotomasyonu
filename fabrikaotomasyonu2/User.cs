using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrikaotomasyonu2
{
    class User
    {

        public string tc { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string adres { get; set; }
        public DateTime dogumtarihi { get; set; }
        public string eposta { get; set; }
        public string telefon { get; set; }
        public bool yonetici { get; set; }
        public bool kimyager { get; set; }
        public bool uretimmuduru { get; set; }
        public bool depo { get; set; }
        public bool pazarlama { get; set; }
        public bool muhasebe { get; set; }
        public int maas { get; set; }
        public string kullaniciadi { get; set; }
        public string sifre { get; set; }
        public string gizlisoru { get; set; }
        public string cevap { get; set; }
        public DateTime is_baslangic { get; set; }
    }
}
