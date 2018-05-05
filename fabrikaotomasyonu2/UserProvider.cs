using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace fabrikaotomasyonu2
{

    public struct musteriBilgi
    {
        public string musteriAdi;
        public string musteriSoyad;
        public string musteriEpost;
        public string  musteriTelefon;
        public Int64 musteriTcKimlik;
        public string musteriAdres;
    }
    public struct gelir_giderBilgi
    {
        public string tip;
        public string kurum;
        public string tarih;
        public int fiyat;
        public string not;
    }

    public struct tedarikciBilgi
    {
        public string FirmaAdi;
        public string Tc;
        public string Ad;
        public string Soyad;
        public string Email;
        public string Tel;
        public string Adres;
        
    }

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

        public bool MusteriEkle(musteriBilgi musteri)
        {          
                 bool result = false;

                  using (var connection = Database.GetConnection())
                     {
                         var command = new SqlCommand("INSERT INTO musteri(musteri_tc,musteri_adi,musteri_soyadi,musteri_mail,musteri_telefon,musteri_adres) " +
                    "VALUES('" + musteri.musteriTcKimlik + "','" + musteri.musteriAdi +
                    "','" + musteri.musteriSoyad + "','" + musteri.musteriEpost + "','" + musteri.musteriTelefon + "','" + musteri.musteriAdres + "')");

                         command.Connection = connection;
                         connection.Open();
                         if (command.ExecuteNonQuery() != -1)
                         {
                             result = true;
                         }
                         connection.Close();
                     }
                 

                 return result;

            
        }

        public DataTable MusteriAra(string musteriAdiSoyadi)
        {
            DataTable dt = null;
            

            string[] adsoyad = musteriAdiSoyadi.Split(' ');

            if (adsoyad.Length >= 2)
            {
                using (var conn = Database.GetConnection())
                {
                    var command = new SqlCommand("Select * from musteri where musteri_adi = '"+adsoyad[0] + "' and musteri_soyadi = '" + adsoyad[1] +"'");
                    command.Connection = conn;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                }
            }

            else if (musteriAdiSoyadi == "" || musteriAdiSoyadi == null)
            {
                using (var conn = Database.GetConnection())
                {
                    var command = new SqlCommand("Select * from musteri");
                    command.Connection = conn;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                }
            }

            else if (adsoyad.Length >= 1)
            {
                using (var conn = Database.GetConnection())
                {
                   
                    var command = new SqlCommand("Select * from musteri where musteri_adi = '" + adsoyad[0] + "' or musteri_soyadi = '" + adsoyad[0] + "'");
                    command.Connection = conn;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                }
            }

            

            
            return dt;
        }



        public bool MusteriBilgiGuncelle(musteriBilgi musteri, Int64 eskitc)
        {
            bool result = false;

            using (var connection = Database.GetConnection())
            {
                string sqlstring = "UPDATE musteri SET musteri_tc = '" + musteri.musteriTcKimlik + "'," +
                                                      "musteri_adi = '" + musteri.musteriAdi + "'," +
                "musteri_soyadi= '" + musteri.musteriSoyad + "'," +
                 "musteri_mail = '" + musteri.musteriEpost + "'," +
                "musteri_telefon = '" + musteri.musteriTelefon + "'," +
                "musteri_adres = '" + musteri.musteriAdres + "' WHERE musteri_tc = '" + eskitc + "'";
                    
                var command = new SqlCommand(sqlstring);



                command.Connection = connection;
                connection.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }


        public bool TedarikciEkle(tedarikciBilgi ted)
        {
            bool result = false;

            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO tedarikci(firmaadi,ad,soyad,eposta,telefon,adres,tc) " +
           "VALUES('" + ted.FirmaAdi + "','" + ted.Ad +
           "','" + ted.Soyad + "','" + ted.Email + "','" + ted.Tel + "','" + ted.Adres + "','"+ted.Tc+"')");

                command.Connection = connection;
                connection.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }


            return result;


        }



        public DataTable TedarikciAra(string TedarikciAdiSoyadi)
        {
            DataTable dt = null;

            string[] adsoyad = TedarikciAdiSoyadi.Split(' ');

            if (adsoyad.Length >= 2)
            {
                using (var conn = Database.GetConnection())
                {
                    var command = new SqlCommand("Select * from tedarikci where ad = '" + adsoyad[0] + "' and soyad = '" + adsoyad[1] + "'");
                    command.Connection = conn;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                }
            }


            else if (TedarikciAdiSoyadi == "" || TedarikciAdiSoyadi == null)
            {
                using (var conn = Database.GetConnection())
                {
                    var command = new SqlCommand("Select * from tedarikci");
                    command.Connection = conn;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                }
            }


            else if (adsoyad.Length >= 1)
            {
                using (var conn = Database.GetConnection())
                {
                    var command = new SqlCommand("Select * from tedarikci where ad = '" + adsoyad[0] + "' or soyad = '" + adsoyad[0] + "'");
                    command.Connection = conn;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                }
            }

            


            return dt;
        }


        public bool TedarikciBilgiGuncelle(tedarikciBilgi ted, string id)
        {
            bool result = false;

            using (var connection = Database.GetConnection())
            {
                string sqlstring = "UPDATE tedarikci SET firmaadi = '" + ted.FirmaAdi + "'," +
                                                      "ad = '" + ted.Ad + "'," +
                "soyad= '" + ted.Soyad + "'," +
                 "eposta = '" + ted.Email + "'," +
                "telefon = '" + ted.Tel + "'," +
                "adres = '" + ted.Adres + "' WHERE tedarikci_id = '" + id + "'";

                var command = new SqlCommand(sqlstring);



                command.Connection = connection;
                connection.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }


        public bool giderEkle(gelir_giderBilgi bilgiler)
        {
            bool result = false;
            
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO gelir_gider(tip,kurum,tarih,fiyat,_not) " +
           "VALUES('" + bilgiler.tip + "','" + bilgiler.kurum +
           "','" + bilgiler.tarih + "','" + bilgiler.fiyat + "','" + bilgiler.not +  "')");

                command.Connection = connection;
                connection.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }


            return result;


        }

        public DataTable giderGoruntule()
        {
            DataTable dt = new DataTable();
            using (var conn = Database.GetConnection())
            {
                var command = new SqlCommand("Select * from gelir_gider WHERE tip='gider'");
                command.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        public DataTable giderAra(string baslangic , string bitis)
        {


            DataTable dt = new DataTable();
            using (var conn = Database.GetConnection())
            {
                //nerde hata yaptık ya bişe dicem hatalı olan ane ki oldu bence. doğru göstermediiii
                var command = new SqlCommand("Select * from gelir_gider WHERE tip='gider' and tarih >= '"+baslangic + "'" + "and tarih <= '"+ bitis+ "'");
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
