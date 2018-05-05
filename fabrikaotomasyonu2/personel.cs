using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace fabrikaotomasyonu2
{
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
        
        }

        /*user oluşturulmuş ama bilgiler db den çekilmemiş*/
        User user = new User();


        UserProvider islem = new UserProvider();
        private void personel_Load(object sender, EventArgs e)
        {



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            this.Hide();
            yonetici yoneticianasayfa = new yonetici();
            yoneticianasayfa.Show();
        }
        private void btn_personel_Click(object sender, EventArgs e)
        {
            this.Hide();
            personel personelpage = new personel();
            personelpage.Show();
        }
        
        private void btn_gider_Click(object sender, EventArgs e)
        {
            this.Hide();
            gider giderpage = new gider();
            giderpage.Show();
        }
        private void btn_musteri_Click(object sender, EventArgs e)
        {
            this.Hide();
            musteri musteripage = new musteri();
            musteripage.Show();
        }
        private void btn_urun_Click(object sender, EventArgs e)
        {
            this.Hide();
            urun urunpage = new urun();
            urunpage.Show();
        }
        private void btn_tedarikci_Click(object sender, EventArgs e)
        {
            this.Hide();
            tedarikçi tedarikcipage = new tedarikçi();
            tedarikcipage.Show();
        }
        private void btn_malzeme_Click(object sender, EventArgs e)
        {
            this.Hide();
            malzeme malzemepage = new malzeme();
            malzemepage.Show();
        }
        private void btn_siparis_Click(object sender, EventArgs e)
        {
            this.Hide();
            siparis siparispage = new siparis();
            siparispage.Show();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            user.tc = txt_ekle_tc.Text;
            user.ad = txt_personel_ekle_ad.Text;
            user.soyad = txt_personel_ekle_soyad.Text;
            user.adres = txt_ekle_adres.Text;
            user.dogumtarihi = dogumtarihi.Value;
            user.eposta = txt_ekle_posta.Text;
            user.telefon = txt_ekle_telefon.Text;
            string yetki = comboBox_ekle_yetki.Text;
            if(string.Compare(yetki,"Yetki Yok") == 1)
            {
                user.yonetici = false;
                user.muhasebe = false;
                user.kimyager = false;
                user.pazarlama = false;
                user.uretimmuduru = false;
                user.depo = false;

            }
            else if(string.Compare(yetki, "Yönetici") == 1)
            {
                user.yonetici = true;
                user.muhasebe = false;
                user.kimyager = false;
                user.pazarlama = false;
                user.uretimmuduru = false;
                user.depo = false;
            }
            else if(string.Compare(yetki, "Depo Elemanı")==1)
            {
                user.yonetici = false;
                user.muhasebe = false;
                user.kimyager = false;
                user.pazarlama = false;
                user.uretimmuduru = false;
                user.depo = true;
            }
            else if(string.Compare(yetki, "Kimyager") == 1)
            {
                user.yonetici = false;
                user.muhasebe = false;
                user.kimyager = true;
                user.pazarlama = false;
                user.uretimmuduru = false;
                user.depo = false;
            }
            else if(string.Compare(yetki, "Üretim Müdürü") == 1)
            {
                user.yonetici = false;
                user.muhasebe = false;
                user.kimyager = false;
                user.pazarlama = false;
                user.uretimmuduru = true;
                user.depo = false;
            }
            else if(string.Compare(yetki, "Alım-Satım") == 1)
            {
                user.yonetici = false;
                user.muhasebe = false;
                user.kimyager = false;
                user.pazarlama = true;
                user.uretimmuduru = false;
                user.depo = false;
            }
            else if (string.Compare(yetki, "Muhasebe") == 1)
            {
                user.yonetici = false;
                user.muhasebe = true;
                user.kimyager = false;
                user.pazarlama = false;
                user.uretimmuduru = false;
                user.depo = false;
            }
            user.maas = Convert.ToInt32(txt_ekle_maas.Text);
            user.kullaniciadi = txt_ekle_kadi.Text;
            user.sifre = txt_ekle_sifre.Text;
            user.gizlisoru = txt_ekle_gizlisoru.Text;
            user.cevap = txt_ekle_cevap.Text;
            user.is_baslangic = isbaslangicpicker.Value;
            if (islem.InsertUser(user))
            {
                MessageBox.Show("Kullanıcı Eklendi");

            }
            else
            {
                MessageBox.Show("Hata !");
            }
        }

        private void selected(object sender, TabControlEventArgs e)
        {
           

            List<string> teams = new List<string>();
            foreach (DataRow dataRow in islem.getUserList().Rows)
            {
                teams.Add(dataRow["ad"].ToString() + " " + dataRow["soyad"].ToString() ) ;
            }
            listBox1.DataSource = teams;

        }
    }
}
