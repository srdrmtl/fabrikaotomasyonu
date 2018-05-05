# FABRİKA OTOMASYONU


1. Proje dosyalarını kendi bilgisayarımıza yüklüyoruz.

```sh
$ git clone https://github.com/srdrmtl/fabrikaotomasyonu.git
```
2. Microsoft Sql Server Management Studio ' yu açıyoruz.
3. Databases Sağ Tıklayıp ,New Database Diyoruz.
4. 'fabrika' adında bir veritabanı oluşturuyoruz.
5. sqldump.sql dosyasını Microsoft Sql Server Management ile Açıyoruz.
6. Execute diyoruz.
7. Projeyi Visual Studio'da açıyoruz.
8. Database.cs Classını açıyoruz.
8. Data Source bilgileri kendimizinkiyle değiştiriyoruz.
```sh
            string connectionString = @"Data Source=SERDAR;Initial Catalog=fabrika;Integrated Security=True";
```
9. Data Source Bilgilerini bilmiyorsanız Project->Add New Data Source diyoruz.
10. Next->Next Diyip , New Connection Diyoruz.
11. Server Name kısmına '.' Yazıyoruz.
12. Select or Enter Database name kısmından fabrika seçiyoruz.
13.Connection String that you will save in the application kısmında + işaretine tıklayıp Data Source bilgilerini öğrenebilirsiniz.
