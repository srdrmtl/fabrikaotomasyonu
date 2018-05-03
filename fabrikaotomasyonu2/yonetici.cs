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
    public partial class yonetici : Form
    {
        giderprovider islem = new giderprovider();
        public yonetici()
        {
            InitializeComponent();

            isimsoyisim.Text = (UserProvider.ad + " " + UserProvider.soyad).ToUpper();





        }

        private void btn_personel_Click(object sender, EventArgs e)
        {
            this.Hide();
            personel personelpage = new personel();
            personelpage.Show();
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            this.Hide();
            yonetici yoneticianasayfa = new yonetici();
            yoneticianasayfa.Show();
        }



        private void panel_yonetici_anasayfa_Paint(object sender, PaintEventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void yonetici_Load(object sender, EventArgs e)
        {
            DataTable gidertable = new DataTable();
            gidertable = islem.getgider();
            dataGridView1.DataSource = gidertable;


            dataGridView1.BackgroundColor = Color.FromArgb(192, 192, 255);
            dataGridView1.Columns["id"].HeaderText = "ID'SI";
            dataGridView1.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["tip"].HeaderText = "TİP";
            dataGridView1.Columns["tip"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["kurum"].HeaderText = "KURUM";
            dataGridView1.Columns["kurum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["tarih"].HeaderText = "TARİH";
            dataGridView1.Columns["tarih"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["fiyat"].HeaderText = "FİYAT";
            dataGridView1.Columns["fiyat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["_not"].HeaderText = "NOT";
            dataGridView1.Columns["_not"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns["id"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            dataGridView1.Columns["tip"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            dataGridView1.Columns["kurum"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            dataGridView1.Columns["tarih"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            dataGridView1.Columns["fiyat"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            dataGridView1.Columns["_not"].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 8, FontStyle.Bold);

            int tpm_gider = 0;
            int tpm_gelir = 0;
            int tpm_all = 0;

            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                Application.DoEvents();
               
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

                string a = Convert.ToString(dataGridView1.Rows[i].Cells["tip"].Value);

               if (string.Compare(a, "gider") == 1)
                {
                    renk.BackColor = Color.Crimson;
                    tpm_gider += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);

                }
               else if(string.Compare(a,"gelir")==1)
                {
                    renk.BackColor = Color.ForestGreen;

                    tpm_gelir += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);

                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }

            txt_toplamgider.Text = tpm_gider.ToString() + " TL";
            txt_toplamgelir.Text = tpm_gelir.ToString() + " TL";
            tpm_all = tpm_gelir - tpm_gider;
            txt_toplam.Text = tpm_all.ToString() + " TL";


            Pen p = new Pen(Color.Black, 1);
            Graphics g = this.CreateGraphics();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Legends.Add("MyLegend");
            chart1.Legends[0].LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Table;
            chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "Pasta Grafiği";
            chart1.Legends[0].BorderColor = Color.Black;
            
            string seriesname = "MySeriesName";
            chart1.Series.Add(seriesname);
            
            //set the chart-type to "Pie"
            chart1.Series[seriesname].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart1.Series[seriesname].Points.AddXY("Gelir", tpm_gelir);
            chart1.Series[seriesname].Points.AddXY("Gider", tpm_gider);
            chart1.Series[seriesname].Points[0].Color = Color.ForestGreen;
            chart1.Series[seriesname].Points[1].Color = Color.Crimson;

            // chart 2 için

            chart2.Series.Clear();
            chart2.Legends.Clear();
            
            chart2.Series.Add("sutungrafigi");
            chart2.Series["sutungrafigi"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series["sutungrafigi"].Points.AddXY("Gelir", tpm_gelir);
            chart2.Series["sutungrafigi"].Points.AddXY("Gider", tpm_gider);
            chart2.Series["sutungrafigi"].Points[0].Color = Color.ForestGreen;
            chart2.Series["sutungrafigi"].Points[1].Color = Color.Crimson;
        }
    }
}
