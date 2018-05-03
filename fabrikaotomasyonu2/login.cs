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
    public partial class login : Form
    {

        private void label1_click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        public login()
        {
            InitializeComponent();
           
        }

        User user = new User();
        UserProvider islem = new UserProvider();
        public static string kadi = "";
        public static string sifre = "";



        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

          
            kadi = bunifuTextbox1.text;
            sifre = bunifuTextbox2.text;
            user = islem.getUser(bunifuTextbox1.text, bunifuTextbox2.text);
            if(user != null)
            {
                if (user.yonetici)
                {
                    yonetici yoneticipage = new yonetici();
                    yoneticipage.Show();
                    this.Hide();
                }
                else if(user.kimyager)
                {
                    kimyager kimyagerpage = new kimyager();
                    kimyagerpage.Show();
                    this.Hide();
                }
                else if (user.uretimmuduru)
                {
                    uretimmuduru uretimmudurupage = new uretimmuduru();
                    uretimmudurupage.Show();
                    this.Hide();
                }
                else if (user.depo)
                {
                    depocu depocupage = new depocu();
                    depocupage.Show();
                    this.Hide();
                }
                else if (user.pazarlama)
                {
                    alim_satim alimsatimpage = new alim_satim();
                    alimsatimpage.Show();
                    this.Hide();
                }
                else if (user.muhasebe)
                {
                    gelir_gider muhasebepage = new gelir_gider();
                    muhasebepage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Yetkilendirme Hatası !");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Ya da Şifre Hatalı");
            }


        }
    }
}
