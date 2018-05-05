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
    public partial class tedarikçi : Form
    {
        public string tedarikci_id;

        public tedarikçi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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


        private void button1_Click(object sender, EventArgs e)
        {
            tedarikciBilgi ted = new tedarikciBilgi();

            ted.FirmaAdi = textBox_tedarikci_firmaadi.Text.ToString();
            ted.Ad = textBox_tedarikci_ad.Text.ToString();
            ted.Soyad = textBox_tedarikci_soyad.Text.ToString();
            ted.Email = textBox_tedarikci_eposta.Text.ToString();
            ted.Tel = textBox_tedarikci_telefon.Text.ToString();
            ted.Adres = richTextBox_tedarikci_adres.Text.ToString();
            ted.Tc = textBox_tedarikci_tc.Text.ToString();
            UserProvider pro = new UserProvider();
            if (pro.TedarikciEkle(ted))
            {
                MessageBox.Show("Başarıyla Kaydedildi.");

            }
            else
            {
                MessageBox.Show("Kayıt alınırken bir hata oluştu");
            }


        }























        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string adisoyadi = textBox5.Text.ToString();

            UserProvider pro = new UserProvider();
            DataTable dt = pro.TedarikciAra(adisoyadi);

            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_guncelle_firmaadi.Text = dataGridView1.Rows[e.RowIndex].Cells["firmaadi"].Value.ToString();
            textBox_guncelle_ad.Text = dataGridView1.Rows[e.RowIndex].Cells["ad"].Value.ToString();
            textBox_guncelle_soyad.Text = dataGridView1.Rows[e.RowIndex].Cells["soyad"].Value.ToString();
            textBox_guncelle_mail.Text = dataGridView1.Rows[e.RowIndex].Cells["eposta"].Value.ToString();
            textBox_guncelle_telefon.Text = dataGridView1.Rows[e.RowIndex].Cells["telefon"].Value.ToString();

            textBox_guncelle_adres.Text = dataGridView1.Rows[e.RowIndex].Cells["adres"].Value.ToString();

            tedarikci_id = dataGridView1.Rows[e.RowIndex].Cells["tedarikci_id"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tedarikciBilgi ted = new tedarikciBilgi();

            ted.FirmaAdi = textBox_guncelle_firmaadi.Text.ToString();
            ted.Ad = textBox_guncelle_ad.Text.ToString();
            ted.Soyad = textBox_guncelle_soyad.Text.ToString();
            ted.Email = textBox_guncelle_mail.Text.ToString();
            ted.Adres = textBox_guncelle_adres.Text.ToString();
            ted.Tel = textBox_guncelle_telefon.Text.ToString();

            UserProvider pro = new UserProvider();
            if(pro.TedarikciBilgiGuncelle(ted, tedarikci_id))
            {
                MessageBox.Show("Başarıyla Güncellendi");
            }
            else
            {
                MessageBox.Show("Hata oluştu !");
            }
        }

        private void load_tedarikci_listele(object sender, EventArgs e)
        {
            UserProvider islem = new UserProvider();
            DataTable dt = islem.TedarikciAra("");

            dataGridView1.DataSource = dt;
        }
    }
}
