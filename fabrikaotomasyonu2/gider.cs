using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fabrikaotomasyonu2
{
    public partial class gider : Form
    {
        public gider()
        {
            InitializeComponent();
        }

        private void gider_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void btn_gider_ekle_Click(object sender, EventArgs e)
        {

            DateTime myDateTime = dateTimePicker1.Value;


            gelir_giderBilgi bilgiler = new gelir_giderBilgi();
            bilgiler.tip = "gider";
            bilgiler.kurum = txt_gider_kurum.Text.ToString();
            bilgiler.tarih = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            bilgiler.fiyat = Convert.ToInt32(txt_gider_miktar.Text);
            bilgiler.not = richTextBox_gider_not.Text.ToString();

            UserProvider islem = new UserProvider();
            if (islem.giderEkle(bilgiler))
            {
                MessageBox.Show("Başarıyla Eklendi.");

            }
            else
            {
                MessageBox.Show("Upss. Bir Hata Oluştu !");
            }
        }

        private void load_giderler(object sender, EventArgs e)
        {
            UserProvider islem = new UserProvider();
            DataTable dt = islem.giderGoruntule();

            dataGridView1.DataSource = dt;
        }

        private void btn_gider_ara_Click(object sender, EventArgs e)
        {


            DateTime baslangic = dateTimeBaslangic.Value;
            DateTime bitis = dateTimeBitis.Value;
               
                string x = baslangic.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string y = bitis.ToString("yyyy-MM-dd HH:mm:ss.fff");

            UserProvider islem = new UserProvider();
            DataTable dt = islem.giderAra(x,y);

            dataGridView1.DataSource = dt;

            baslangiclabel.Text = baslangic.ToString("yyyy-MM-dd");
            bitislabel.Text=bitis.ToString("yyyy-MM-dd");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
