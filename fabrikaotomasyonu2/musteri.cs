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
    
   

    public partial class musteri : Form
    {
        public Int64 musteri_tc_tut;

        public musteri()
        {
            InitializeComponent();
        }

       

      




        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
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


        private void musteriEkleButton_Click(object sender, EventArgs e)
        {
            string musteriAdi = Txt_musteri_ad.Text.ToString();
            string musteriSoyad = txt_Musteri_soyad.Text.ToString();
            string musteriEposta = txt_Musteri_posta.Text.ToString();
            string musteriTelefon = txt_Musteri_telefon.Text.ToString();
            Int64 musteriTcKimlik = Convert.ToInt64(txt_Musteri_tc.Text);
            string musteriAdres = richTextBox1_musteri_adres.Text.ToString();

            musteriBilgi deneme = new musteriBilgi();

            deneme.musteriAdi = musteriAdi;
            deneme.musteriSoyad = musteriSoyad;
            deneme.musteriEpost = musteriEposta;
            deneme.musteriTelefon = musteriTelefon;
            deneme.musteriTcKimlik = musteriTcKimlik;
            deneme.musteriAdres = musteriAdres;

            UserProvider musteriEkle = new UserProvider();
            if (musteriEkle.MusteriEkle(deneme))
            {
                MessageBox.Show("Müşteri Başarıyla Eklendi");

            }
            else
            {
                MessageBox.Show("Müşteri Eklerken Hata Oluştu");
            }

        }


        private void musteriAraButton_Click(object sender, EventArgs e)
        {
            string musteriAdSoyad = textBox6.Text.ToString();

            UserProvider ara = new UserProvider();
            DataTable dt = ara.MusteriAra(musteriAdSoyad);

            dataGridView1.DataSource = dt;
        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["musteri_adi"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["musteri_soyadi"].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["musteri_mail"].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["musteri_telefon"].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["musteri_tc"].Value.ToString();
            richTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["musteri_adres"].Value.ToString();

            musteri_tc_tut = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["musteri_tc"].Value);
        }

        private void musteriBilgileriGuncelleButton_Click(object sender, EventArgs e)
        {
            musteriBilgi musteri = new musteriBilgi();
            musteri.musteriAdi = textBox7.Text.ToString();
            musteri.musteriSoyad = textBox8.Text.ToString();
            musteri.musteriEpost = textBox9.Text.ToString();
            musteri.musteriTelefon = textBox10.Text.ToString();
            musteri.musteriAdres = richTextBox2.Text.ToString();

            UserProvider guncelle = new UserProvider();
            if(guncelle.MusteriBilgiGuncelle(musteri, musteri_tc_tut))
            {
                MessageBox.Show("Başarıyla Güncellendi");
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }

        }

        private void load_musteri_listele(object sender, EventArgs e)
        {
            UserProvider ara = new UserProvider();
            DataTable dt = ara.MusteriAra("");

            dataGridView1.DataSource = dt;
        }
    }
}
