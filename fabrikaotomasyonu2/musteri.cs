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
    }
}
