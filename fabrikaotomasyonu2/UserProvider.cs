using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace fabrikaotomasyonu2
{
    class UserProvider
    {
        public static string ad;
        public static string soyad;
        public User getUser(string kullaniciadi, string sifre)
        {

            User user = null;

            using (var conn = Database.GetConnection())
            {
                var command = new SqlCommand("Select * from kullanici where kullaniciadi='" + kullaniciadi + "' and sifre = '" + sifre + "'");

                command.Connection = conn;
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User();
                        user.tc = reader.GetString(0);
                        user.kullaniciadi = reader.GetString(14);
                        user.sifre = reader.GetString(15);
                        user.yonetici = reader.GetBoolean(7);
                        user.kimyager = reader.GetBoolean(8);
                        user.uretimmuduru = reader.GetBoolean(9);
                        user.depo = reader.GetBoolean(10);
                        user.pazarlama = reader.GetBoolean(11);
                        user.muhasebe = reader.GetBoolean(12);
                        ad = reader.GetString(1);
                        soyad = reader.GetString(2);
                    }
                }
                conn.Close();
            }
            return user;
        }


        private bool ContainsUser(User user)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM kullanici WHERE kullaniciadi='" + user.kullaniciadi + "'");
                //var command = new SqlCommand("SELECT *FROM Users WHERE Name='" + user.Name + "' and Password='" + user.Password + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;
        }


        public bool InsertUser(User user)
        {

            bool result = false;

            if (!ContainsUser(user))
            {
                using (var connection = Database.GetConnection())
                {
                    var command = new SqlCommand("INSERT INTO kullanici(tc,ad,soyad,adres,dogumtarihi,eposta,telefon" +
                        ",yonetici,kimyager,uretimmuduru,depo,pazarlama,muhasebe,maas,kullaniciadi,sifre," +
                        "gizlisoru,gizlicevap,is_baslangic) " +
                        "VALUES('" + user.tc + "','" + user.ad + "','"+user.soyad+ "','"+ user.adres+ "','"+user.dogumtarihi+ "','"+user.eposta+ "','"+user.telefon+ "','"+user.yonetici+ "','"+user.kimyager+ "','"+user.uretimmuduru+ "','"+user.depo+ "','"+user.pazarlama+ "','"+user.muhasebe+ "','"+user.maas+ "','"+user.kullaniciadi+ "','"+user.sifre+ "','"+user.gizlisoru+ "','"+user.cevap+ "','"+user.is_baslangic+ "')");
                    command.Connection = connection;
                    connection.Open();
                    if (command.ExecuteNonQuery() != -1)
                    {
                        result = true;
                    }
                    connection.Close();
                }
            }
          
            return result;

        }


        public DataTable getUserList()
        {
            DataTable dt = null;
            using (var conn = Database.GetConnection())
            {
                var command = new SqlCommand("Select * from kullanici");
                command.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
    }
}
